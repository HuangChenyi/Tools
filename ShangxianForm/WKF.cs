using Ede.Uof.EIP.Organization.Util;
using Ede.Uof.Utility.Data;
using Ede.Uof.WKF.Design;
using Ede.Uof.WKF.Design.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShangxianForm
{
    public class WKF
    {

        internal FormVersionPO formVersionPo = new FormVersionPO();
        DBHelper db = new DBHelper();
        FlowPO flowPo = new FlowPO();

        /// <summary>
        /// 主流程DataSet
        /// </summary>
        private MasterFlowDataSet.TB_WKF_SITEDataTable newSiteTB = new MasterFlowDataSet.TB_WKF_SITEDataTable();
        /// <summary>
        /// 副流程DataSet
        /// </summary>
        private SubFlowDataSet.TB_WKF_SITEDataTable newSiteSubTB = new SubFlowDataSet.TB_WKF_SITEDataTable();

        /// <summary>
        /// 刪除表單版本
        /// </summary>
        /// <param name="formVersionId"></param>
        /// <param name="setupFlowUCO"></param>
        public void DeleteFormVersion(string formVersionId, SetupFlowUCO setupFlowUCO, string userGuid)
        {
            DatabaseHelper dbHelper = new DatabaseHelper();
            FormConditionPO formConditionPO = new FormConditionPO();
            FormVersionDataSet formVersionDataSet = this.formVersionPo.QueryFormVersion(formVersionId);

            DataRow drFormVersion = formVersionDataSet.FormVersion.Rows[0];


            try
            {

                formVersionPo.BeginTransaction(dbHelper);
                // ==========================================================
                this.formVersionPo.DeleteFormVersion(formVersionId);    //刪除表單版本
                formConditionPO.DeleteAllFormCondMember(formVersionId); //刪除條件成員
                formConditionPO.DeleteAllFormCond(formVersionId);       //刪除條件                    

                //如果有主流程則刪除流程
                if (drFormVersion["FLOW_ID"] != DBNull.Value)
                {
                    DeleteMasterFlow(formVersionId, drFormVersion["FLOW_ID"].ToString(), dbHelper, false, userGuid);
                }
                //刪除條件知會
                DeleteSiteNodifyByFormVersion(formVersionId);
                // ==========================================================
                this.formVersionPo.CommitTransaction();
            }
            catch (Exception ex)
            {
                this.formVersionPo.RollbackTransaction();
                throw ex;
            }


        }

        /// <summary>
        /// 刪除條件知會
        /// </summary>
        /// <param name="formVersionId">表單版本代號</param>
        /// <remark>
        
        /// </remark>
        private void DeleteSiteNodifyByFormVersion(string formVersionId)
        {
            db.DeleteSiteNodifyByFormVersion(formVersionId);
        }

       

        void DeleteMasterFlow(string formVersionId, string flowId, DatabaseHelper dbHelper, bool allowCommit, string userGuid)
        {
            FormVersionPO formVersionPo = new FormVersionPO();
            MasterFlow masterFlow = GetMasterFlow(flowId);

            try
            {
                this.flowPo.BeginTransaction(dbHelper);
                formVersionPo.BeginTransaction(dbHelper);

                foreach (Site site in masterFlow.sitesAl)
                {
                    DeleteSite(site, userGuid);  //刪除站點與相關資訊                 
                }
                this.flowPo.DeleteFlow(flowId); //刪除流程
                formVersionPo.UpdateFormVersionFlowId(formVersionId, null, userGuid, UserTime.SetZone(userGuid).GetNowForDb()); //清空表表單版本流程ID

                if (allowCommit)
                {
                    this.flowPo.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                this.flowPo.RollbackTransaction();
                throw ex;
            }
        }

        /// <summary>
        /// 刪除站點
        /// </summary>
        /// <param name="site"></param>
        public void DeleteSite(Site site, string userGuid)
        {
            switch (site.siteType)
            {
                // ========== 簽核式 ==========
                case Site.SiteType.SignAbleSite:
                    {
                        SignableSite signableSite = (SignableSite)site;
                        DeleteSignableSite(signableSite.siteId, signableSite.ParentSiteId, userGuid);
                        break;
                    }
                // ========== 流程式 ==========
                case Site.SiteType.FlowSite:
                    {
                        DeleteFlowSite(site.siteId, userGuid);
                        break;
                    }
                // ========== 平行式流程 ==========
                case Site.SiteType.ParallelFlowsite:
                    {
                        DeleteParallelFlowSite(site.siteId, userGuid);
                        break;
                    }
                // ========== 分岔式 ==========
                case Site.SiteType.BranchSite:
                    {
                        DeleteBranchSite(site.siteId, userGuid);
                        break;
                    }
                // ========== 自訂站點 ==========
                case Site.SiteType.CustDesignFlowSite:
                    {
                        //自訂不用刪，自訂的流程可能多個站點同時使用..
                        this.flowPo.DeleteSite(site.siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());
                        break;
                    }
                // ========== 自選站點 ==========
                case Site.SiteType.CustGroupFlowSite:
                    {
                        //自選要把自選流程新增的資料刪除..
                        this.flowPo.DeleteSite(site.siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());
                        this.flowPo.DeleteCustGroupFlowSite(site.siteId);
                        break;
                    }
                // ========== 表單欄位式站點 ==========
                case Site.SiteType.FieldFlowSite:
                    {
                        //表單欄位式站點刪除..
                        FieldSite fieldSite = (FieldSite)site;
                        DeleteFieldSite(fieldSite.siteId, fieldSite.ParentSiteId, userGuid);
                        break;
                    }
                // ========== 應用程式站點(外部接口)=========
                case Site.SiteType.ExternalFlowSite:
                    {
                        DeleteExternalSite(site.siteId, userGuid);
                        break;
                    }
                // ========== 知會站點=========
                case Site.SiteType.AlertSite:
                    {
                        AlertSite alertSite = (AlertSite)site;
                        DeleteAlertSite(alertSite.siteId, alertSite.ParentSiteId, userGuid);
                        break;
                    }
            }
        }

        private void DeleteParallelFlowSite(string siteId, string userGuid)
        {
            this.flowPo.DeleteSite(siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());
        }

        /// <summary>
        /// 刪除簽核式站點
        /// </summary>
        /// <param name="siteId">站點代號</param>
        /// <param name="parentSiteId">站點所屬代號</param>
        public void DeleteSignableSite(string siteId, string parentSiteId, string userGuid)
        {
            try
            {
                this.flowPo.DeleteSite(siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());                     //刪除站點資訊
                this.flowPo.DeleteSignAbleSite(siteId);             //刪除簽核式站點
                this.flowPo.DeleteEndCond(siteId, parentSiteId);    //刪除結案條件
                this.flowPo.DeleteFVRWebService(siteId);            //刪除站點Web Service
                this.db.DeleteFVRDll(siteId);                   //刪除站點Dll (add by lichan 2010/05/25)
                this.flowPo.DeleteFVRRemark(siteId);                //刪除站點備註
                this.flowPo.DeleteFVRCode(siteId);                  //刪除站點代號
                this.flowPo.DeleteFVRMail(siteId);                  //刪除站點郵件
                this.db.DeleteFvrCustomWords(siteId, parentSiteId);//刪除自訂簽核文字
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 刪除知會站點
        /// </summary>
        /// <param name="siteId">站點代號</param>
        /// <param name="parentSiteId">站點所屬代號</param>
        public void DeleteAlertSite(string siteId, string parentSiteId, string userGuid)
        {
            try
            {
                //刪除站點資訊
                this.flowPo.DeleteSite(siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());
                //刪除知會站點  
                this.db.DeleteAlertSite(siteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 刪除表單欄位式站點
        /// </summary>
        /// <param name="siteId"></param>
        /// <param name="parentSiteId"></param>
        public void DeleteFieldSite(string siteId, string parentSiteId, string userGuid)
        {
            try
            {
                this.flowPo.DeleteSite(siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());                     //刪除站點資訊
                this.flowPo.DeleteFieldSite(siteId);                //刪除簽核式站點
                this.flowPo.DeleteEndCond(siteId, parentSiteId);    //刪除結案條件
                this.flowPo.DeleteFVRWebService(siteId);            //刪除站點Web Service
                this.db.DeleteFVRDll(siteId);                   //刪除站點Dll (add by lichan 2010/05/25)
                this.flowPo.DeleteFVRRemark(siteId);                //刪除站點備註
                this.flowPo.DeleteFVRCode(siteId);                  //刪除站點代號
                this.flowPo.DeleteFVRMail(siteId);                  //刪除站點郵件
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// 刪除流程式站點
        /// </summary>
        /// <param name="siteId">站點代號</param>
        public void DeleteFlowSite(string siteId, string userGuid)
        {
            try
            {
                // ===================================================
                this.flowPo.DeleteSite(siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());         //刪除站點資訊
                this.flowPo.DeleteFlowSite(siteId);     //刪除流程式站點
                this.flowPo.DeleteEndCond(siteId);      //刪除結案條件
                this.flowPo.DeleteFVRWebService(siteId);//刪除站點Web Service
                this.db.DeleteFVRDllByFlowSite(siteId);       //刪除站點Dll (add by lichan 2010/05/25)
                this.flowPo.DeleteFVRRemark(siteId);    //刪除站點備註
                this.flowPo.DeleteFVRCode(siteId);      //刪除站點代號
                this.flowPo.DeleteFVRMail(siteId);      //刪除站點郵件
                // ===================================================
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 刪除分岔式站點
        /// </summary>
        /// <param name="siteId">站點代號</param>
        public void DeleteBranchSite(string siteId, string userGuid)
        {
            try
            {
                this.flowPo.DeleteSite(siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());         //刪除站點資訊
                this.flowPo.DeleteBranchSite(siteId);   //刪除分岔式站點
                this.flowPo.DeleteBranchNode(siteId);   //刪除分岔式站點節點
                this.flowPo.DeleteBranchCond(siteId);   //刪除分岔式站點條件
                this.flowPo.DeleteEndCond(siteId);      //刪除結案條件
                this.flowPo.DeleteFVRWebService(siteId);//刪除站點Web Service
                this.db.DeleteFVRDllByFlowSite(siteId);       //刪除站點Dll (add by lichan 2010/05/25)
                this.flowPo.DeleteFVRRemark(siteId);    //刪除站點備註
                this.flowPo.DeleteFVRCode(siteId);      //刪除站點代號
                this.flowPo.DeleteFVRMail(siteId);      //刪除站點郵件
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 刪除應用程式站點(外部接口站點)
        /// </summary>
        /// <param name="siteId">The site id.</param>
        public void DeleteExternalSite(string siteId, string userGuid)
        {
            try
            {

                this.flowPo.DeleteSite(siteId, userGuid, UserTime.SetZone(userGuid).GetNowForDb());         //刪除站點資訊               
                //this.flowPo.DeleteEndCond(siteId);      //刪除結案條件
                //this.flowPo.DeleteFVRWebService(siteId);//刪除站點Web Service
                this.db.DeleteFVRDll(siteId);       //刪除站點Dll (add by lichan 2010/05/25)
                //this.flowPo.DeleteFVRRemark(siteId);    //刪除站點備註
                //this.flowPo.DeleteFVRCode(siteId);      //刪除站點代號
                //this.flowPo.DeleteFVRMail(siteId);      //刪除站點郵件
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 重新組合主流程
        /// </summary>
        /// <param name="siteTB"></param>
        /// <returns></returns>
        private MasterFlowDataSet.TB_WKF_SITEDataTable GetFlowSite(MasterFlowDataSet.TB_WKF_SITEDataTable siteTB)
        {
            newSiteTB.Clear();

            if (siteTB.Rows.Count == 1)
            {
                newSiteTB.ImportRow(siteTB.Rows[0]);
                return newSiteTB;
            }

            //先找出第一站
            foreach (MasterFlowDataSet.TB_WKF_SITERow oldSiteRow in siteTB.Rows)
            {
                if (oldSiteRow.IsPREV_SITE_IDNull())
                {
                    newSiteTB.ImportRow(oldSiteRow);
                    GetFlowSiteRow(oldSiteRow.SITE_ID, siteTB);
                }
            }

            return newSiteTB;
        }

        /// <summary>
        /// 重新組合主流程
        /// </summary>
        /// <param name="thisSiteId"></param>
        /// <param name="siteTB"></param>
        private void GetFlowSiteRow(string thisSiteId, MasterFlowDataSet.TB_WKF_SITEDataTable siteTB)
        {
            foreach (MasterFlowDataSet.TB_WKF_SITERow siteRow in siteTB.Rows)
            {
                if (!siteRow.IsPREV_SITE_IDNull())
                {
                    if (siteRow.PREV_SITE_ID == thisSiteId)
                    {
                        newSiteTB.ImportRow(siteRow);

                        if (!siteRow.IsNEXT_SITE_IDNull())
                        {
                            GetFlowSiteRow(siteRow.SITE_ID, siteTB);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 取得主流程物件
        /// </summary>
        /// <param name="subFlowId">副流程id</param>
        /// <returns>主流程物件</returns>
        public MasterFlow GetMasterFlow(string subFlowId)
        {
            //取得主流程資訊
            MasterFlowDataSet masterFlowDs = flowPo.GetMasterFlowDataSet(subFlowId);
            MasterFlowDataSet.TB_WKF_SITEDataTable newSiteTB = GetFlowSite(masterFlowDs.TB_WKF_SITE);
            masterFlowDs.TB_WKF_SITE.Clear();

            foreach (MasterFlowDataSet.TB_WKF_SITERow siteRow in newSiteTB.Rows)
            {
                masterFlowDs.TB_WKF_SITE.ImportRow(siteRow);
            }

            //建立主流程物件
            MasterFlow masterFlow = new MasterFlow(masterFlowDs);

            return masterFlow;
        }
    }
}

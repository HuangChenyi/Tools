﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 原始程式碼已由 Microsoft.VSDesigner 自動產生，版本 4.0.30319.42000。
// 
#pragma warning disable 1591

namespace UploadPhoto.File {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="FileCenterSoap", Namespace="http://tempuri.org/")]
    public partial class FileCenter : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AllocFileSessionOperationCompleted;
        
        private System.Threading.SendOrPostCallback CommitFileGroupOperationCompleted;
        
        private System.Threading.SendOrPostCallback WriteFileSessionOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConvertFileSessionToFileGroupOperationCompleted;
        
        private System.Threading.SendOrPostCallback ConvertFileSessionToFileGroup2OperationCompleted;
        
        private System.Threading.SendOrPostCallback ConvertFileSessionToFileGroup3OperationCompleted;
        
        private System.Threading.SendOrPostCallback ConvertFileSessionToFileGroup4OperationCompleted;
        
        private System.Threading.SendOrPostCallback ClearFileSessionOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public FileCenter() {
            this.Url = global::UploadPhoto.Properties.Settings.Default.UploadPhoto_File_FileCenter;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event AllocFileSessionCompletedEventHandler AllocFileSessionCompleted;
        
        /// <remarks/>
        public event CommitFileGroupCompletedEventHandler CommitFileGroupCompleted;
        
        /// <remarks/>
        public event WriteFileSessionCompletedEventHandler WriteFileSessionCompleted;
        
        /// <remarks/>
        public event ConvertFileSessionToFileGroupCompletedEventHandler ConvertFileSessionToFileGroupCompleted;
        
        /// <remarks/>
        public event ConvertFileSessionToFileGroup2CompletedEventHandler ConvertFileSessionToFileGroup2Completed;
        
        /// <remarks/>
        public event ConvertFileSessionToFileGroup3CompletedEventHandler ConvertFileSessionToFileGroup3Completed;
        
        /// <remarks/>
        public event ConvertFileSessionToFileGroup4CompletedEventHandler ConvertFileSessionToFileGroup4Completed;
        
        /// <remarks/>
        public event ClearFileSessionCompletedEventHandler ClearFileSessionCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/AllocFileSession", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string AllocFileSession(string token, FileTarget fileTarget, int fileLength) {
            object[] results = this.Invoke("AllocFileSession", new object[] {
                        token,
                        fileTarget,
                        fileLength});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AllocFileSessionAsync(string token, FileTarget fileTarget, int fileLength) {
            this.AllocFileSessionAsync(token, fileTarget, fileLength, null);
        }
        
        /// <remarks/>
        public void AllocFileSessionAsync(string token, FileTarget fileTarget, int fileLength, object userState) {
            if ((this.AllocFileSessionOperationCompleted == null)) {
                this.AllocFileSessionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAllocFileSessionOperationCompleted);
            }
            this.InvokeAsync("AllocFileSession", new object[] {
                        token,
                        fileTarget,
                        fileLength}, this.AllocFileSessionOperationCompleted, userState);
        }
        
        private void OnAllocFileSessionOperationCompleted(object arg) {
            if ((this.AllocFileSessionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AllocFileSessionCompleted(this, new AllocFileSessionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CommitFileGroup", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void CommitFileGroup(string token, string fileGroupId) {
            this.Invoke("CommitFileGroup", new object[] {
                        token,
                        fileGroupId});
        }
        
        /// <remarks/>
        public void CommitFileGroupAsync(string token, string fileGroupId) {
            this.CommitFileGroupAsync(token, fileGroupId, null);
        }
        
        /// <remarks/>
        public void CommitFileGroupAsync(string token, string fileGroupId, object userState) {
            if ((this.CommitFileGroupOperationCompleted == null)) {
                this.CommitFileGroupOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCommitFileGroupOperationCompleted);
            }
            this.InvokeAsync("CommitFileGroup", new object[] {
                        token,
                        fileGroupId}, this.CommitFileGroupOperationCompleted, userState);
        }
        
        private void OnCommitFileGroupOperationCompleted(object arg) {
            if ((this.CommitFileGroupCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CommitFileGroupCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/WriteFileSession", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void WriteFileSession(string token, FileTarget fileTarget, string fileSessionId, int offset, [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")] byte[] buffer) {
            this.Invoke("WriteFileSession", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        offset,
                        buffer});
        }
        
        /// <remarks/>
        public void WriteFileSessionAsync(string token, FileTarget fileTarget, string fileSessionId, int offset, byte[] buffer) {
            this.WriteFileSessionAsync(token, fileTarget, fileSessionId, offset, buffer, null);
        }
        
        /// <remarks/>
        public void WriteFileSessionAsync(string token, FileTarget fileTarget, string fileSessionId, int offset, byte[] buffer, object userState) {
            if ((this.WriteFileSessionOperationCompleted == null)) {
                this.WriteFileSessionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnWriteFileSessionOperationCompleted);
            }
            this.InvokeAsync("WriteFileSession", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        offset,
                        buffer}, this.WriteFileSessionOperationCompleted, userState);
        }
        
        private void OnWriteFileSessionOperationCompleted(object arg) {
            if ((this.WriteFileSessionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.WriteFileSessionCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConvertFileSessionToFileGroup", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConvertFileSessionToFileGroup(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId) {
            object[] results = this.Invoke("ConvertFileSessionToFileGroup", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        fileName,
                        fileGroupId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroupAsync(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId) {
            this.ConvertFileSessionToFileGroupAsync(token, fileTarget, fileSessionId, fileName, fileGroupId, null);
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroupAsync(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId, object userState) {
            if ((this.ConvertFileSessionToFileGroupOperationCompleted == null)) {
                this.ConvertFileSessionToFileGroupOperationCompleted = new System.Threading.SendOrPostCallback(this.OnConvertFileSessionToFileGroupOperationCompleted);
            }
            this.InvokeAsync("ConvertFileSessionToFileGroup", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        fileName,
                        fileGroupId}, this.ConvertFileSessionToFileGroupOperationCompleted, userState);
        }
        
        private void OnConvertFileSessionToFileGroupOperationCompleted(object arg) {
            if ((this.ConvertFileSessionToFileGroupCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConvertFileSessionToFileGroupCompleted(this, new ConvertFileSessionToFileGroupCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConvertFileSessionToFileGroup2", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConvertFileSessionToFileGroup2(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous) {
            object[] results = this.Invoke("ConvertFileSessionToFileGroup2", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        fileName,
                        fileGroupId,
                        isAnonymous});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroup2Async(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous) {
            this.ConvertFileSessionToFileGroup2Async(token, fileTarget, fileSessionId, fileName, fileGroupId, isAnonymous, null);
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroup2Async(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous, object userState) {
            if ((this.ConvertFileSessionToFileGroup2OperationCompleted == null)) {
                this.ConvertFileSessionToFileGroup2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnConvertFileSessionToFileGroup2OperationCompleted);
            }
            this.InvokeAsync("ConvertFileSessionToFileGroup2", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        fileName,
                        fileGroupId,
                        isAnonymous}, this.ConvertFileSessionToFileGroup2OperationCompleted, userState);
        }
        
        private void OnConvertFileSessionToFileGroup2OperationCompleted(object arg) {
            if ((this.ConvertFileSessionToFileGroup2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConvertFileSessionToFileGroup2Completed(this, new ConvertFileSessionToFileGroup2CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConvertFileSessionToFileGroup3", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConvertFileSessionToFileGroup3(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous, string contentType, bool isHidden, bool isCorrectImageOrientain) {
            object[] results = this.Invoke("ConvertFileSessionToFileGroup3", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        fileName,
                        fileGroupId,
                        isAnonymous,
                        contentType,
                        isHidden,
                        isCorrectImageOrientain});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroup3Async(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous, string contentType, bool isHidden, bool isCorrectImageOrientain) {
            this.ConvertFileSessionToFileGroup3Async(token, fileTarget, fileSessionId, fileName, fileGroupId, isAnonymous, contentType, isHidden, isCorrectImageOrientain, null);
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroup3Async(string token, FileTarget fileTarget, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous, string contentType, bool isHidden, bool isCorrectImageOrientain, object userState) {
            if ((this.ConvertFileSessionToFileGroup3OperationCompleted == null)) {
                this.ConvertFileSessionToFileGroup3OperationCompleted = new System.Threading.SendOrPostCallback(this.OnConvertFileSessionToFileGroup3OperationCompleted);
            }
            this.InvokeAsync("ConvertFileSessionToFileGroup3", new object[] {
                        token,
                        fileTarget,
                        fileSessionId,
                        fileName,
                        fileGroupId,
                        isAnonymous,
                        contentType,
                        isHidden,
                        isCorrectImageOrientain}, this.ConvertFileSessionToFileGroup3OperationCompleted, userState);
        }
        
        private void OnConvertFileSessionToFileGroup3OperationCompleted(object arg) {
            if ((this.ConvertFileSessionToFileGroup3Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConvertFileSessionToFileGroup3Completed(this, new ConvertFileSessionToFileGroup3CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ConvertFileSessionToFileGroup4", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ConvertFileSessionToFileGroup4(string token, FileTarget fileTarget, string subModulePath, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous, string contentType, bool isHidden, bool isCorrectImageOrientain) {
            object[] results = this.Invoke("ConvertFileSessionToFileGroup4", new object[] {
                        token,
                        fileTarget,
                        subModulePath,
                        fileSessionId,
                        fileName,
                        fileGroupId,
                        isAnonymous,
                        contentType,
                        isHidden,
                        isCorrectImageOrientain});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroup4Async(string token, FileTarget fileTarget, string subModulePath, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous, string contentType, bool isHidden, bool isCorrectImageOrientain) {
            this.ConvertFileSessionToFileGroup4Async(token, fileTarget, subModulePath, fileSessionId, fileName, fileGroupId, isAnonymous, contentType, isHidden, isCorrectImageOrientain, null);
        }
        
        /// <remarks/>
        public void ConvertFileSessionToFileGroup4Async(string token, FileTarget fileTarget, string subModulePath, string fileSessionId, string fileName, string fileGroupId, bool isAnonymous, string contentType, bool isHidden, bool isCorrectImageOrientain, object userState) {
            if ((this.ConvertFileSessionToFileGroup4OperationCompleted == null)) {
                this.ConvertFileSessionToFileGroup4OperationCompleted = new System.Threading.SendOrPostCallback(this.OnConvertFileSessionToFileGroup4OperationCompleted);
            }
            this.InvokeAsync("ConvertFileSessionToFileGroup4", new object[] {
                        token,
                        fileTarget,
                        subModulePath,
                        fileSessionId,
                        fileName,
                        fileGroupId,
                        isAnonymous,
                        contentType,
                        isHidden,
                        isCorrectImageOrientain}, this.ConvertFileSessionToFileGroup4OperationCompleted, userState);
        }
        
        private void OnConvertFileSessionToFileGroup4OperationCompleted(object arg) {
            if ((this.ConvertFileSessionToFileGroup4Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ConvertFileSessionToFileGroup4Completed(this, new ConvertFileSessionToFileGroup4CompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ClearFileSession", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ClearFileSession(string token, FileTarget fileTarget, string fileSessionId) {
            this.Invoke("ClearFileSession", new object[] {
                        token,
                        fileTarget,
                        fileSessionId});
        }
        
        /// <remarks/>
        public void ClearFileSessionAsync(string token, FileTarget fileTarget, string fileSessionId) {
            this.ClearFileSessionAsync(token, fileTarget, fileSessionId, null);
        }
        
        /// <remarks/>
        public void ClearFileSessionAsync(string token, FileTarget fileTarget, string fileSessionId, object userState) {
            if ((this.ClearFileSessionOperationCompleted == null)) {
                this.ClearFileSessionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnClearFileSessionOperationCompleted);
            }
            this.InvokeAsync("ClearFileSession", new object[] {
                        token,
                        fileTarget,
                        fileSessionId}, this.ClearFileSessionOperationCompleted, userState);
        }
        
        private void OnClearFileSessionOperationCompleted(object arg) {
            if ((this.ClearFileSessionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ClearFileSessionCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.3056.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum FileTarget {
        
        /// <remarks/>
        Album,
        
        /// <remarks/>
        Briefcase,
        
        /// <remarks/>
        Bulletin,
        
        /// <remarks/>
        DMS_SOURCE,
        
        /// <remarks/>
        EIP,
        
        /// <remarks/>
        Forum,
        
        /// <remarks/>
        OMS,
        
        /// <remarks/>
        Personal,
        
        /// <remarks/>
        PMS,
        
        /// <remarks/>
        PrivateMessage,
        
        /// <remarks/>
        QUE,
        
        /// <remarks/>
        WKF,
        
        /// <remarks/>
        UChat,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void AllocFileSessionCompletedEventHandler(object sender, AllocFileSessionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AllocFileSessionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AllocFileSessionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void CommitFileGroupCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void WriteFileSessionCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void ConvertFileSessionToFileGroupCompletedEventHandler(object sender, ConvertFileSessionToFileGroupCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConvertFileSessionToFileGroupCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConvertFileSessionToFileGroupCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void ConvertFileSessionToFileGroup2CompletedEventHandler(object sender, ConvertFileSessionToFileGroup2CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConvertFileSessionToFileGroup2CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConvertFileSessionToFileGroup2CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void ConvertFileSessionToFileGroup3CompletedEventHandler(object sender, ConvertFileSessionToFileGroup3CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConvertFileSessionToFileGroup3CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConvertFileSessionToFileGroup3CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void ConvertFileSessionToFileGroup4CompletedEventHandler(object sender, ConvertFileSessionToFileGroup4CompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ConvertFileSessionToFileGroup4CompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ConvertFileSessionToFileGroup4CompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.3056.0")]
    public delegate void ClearFileSessionCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591

namespace GsbService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.ServiceGsb = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller1 = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceGsb
            // 
            this.ServiceGsb.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.ServiceGsb.Password = null;
            this.ServiceGsb.Username = null;
            // 
            // serviceInstaller1
            // 
            this.serviceInstaller1.Description = "Ce service change l\'état des fiches frais toute les 24h durant une date donnée.";
            this.serviceInstaller1.DisplayName = "Service GSB";
            this.serviceInstaller1.ServiceName = "Service GSB";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ServiceGsb,
            this.serviceInstaller1});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ServiceGsb;
        private System.ServiceProcess.ServiceInstaller serviceInstaller1;
    }
}
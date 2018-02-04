using ConsumeREST;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumeAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Handlers
        private void btnGetResponse_Click(object sender, EventArgs e)
        {
            // Reset the richTextArea
            txtResponse.Clear();


            // New client object; Set the URI explicitly.
            string _URI = txtURI.Text;
            Client client = new Client() { URI = _URI };
            string response = String.Empty;

            // I surround the Request method in a try catch to catch any remaining exceptions
            // that weren't caught in the method itself.
            try
            {
                response = client.Request();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Display the returned JSON
            Display(response);
        }
        #endregion
        #region Helper Methods
        //
        //  Display method
        //  Just for re-useability
        //
        private void Display(string str)
        {
            txtResponse.AppendText(str);
        }
        #endregion
    }
}

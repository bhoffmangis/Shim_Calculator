using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Shim_Calculator
{
    public partial class ShimCalculator : Form
    {
        public ShimCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            decimal mClear; // measured clearance
            decimal cShim;  // current shim
            decimal rClear; // required clearance
            decimal rShim;  // replacement shim
            bool areValidInputs;

            areValidInputs = SetInputs(out mClear, out cShim, out rClear);

            if (areValidInputs == true)
            {
                rShim = (mClear - rClear) + cShim;
                DisplayResult(rShim);
            }
        }

        private bool SetInputs(out decimal mC, out decimal cS, out decimal rC)
        {
            bool allValid = true;
            bool mCValid;
            bool cSValid;
            bool rCValid;

            mCValid = Decimal.TryParse(txtMeasuredClearance.Text, out mC) && (mC >= 0);
            cSValid = Decimal.TryParse(txtCurrentShim.Text, out cS) && (cS >= 0);
            rCValid = Decimal.TryParse(txtRequiredClearance.Text, out rC) && (rC >= 0);

            if (mCValid == false)
            {
                allValid = false;
                MessageBox.Show("Measured clearance must be a non-negative number!",
                    "Invalid Measured Clearance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMeasuredClearance.Focus();
                txtMeasuredClearance.SelectAll();
            }

            else if (cSValid == false)
            {
                allValid = false;
                MessageBox.Show("Current shim size must be a non-negative number!",
                    "Invalid Current Shim Size", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCurrentShim.Focus();
                txtCurrentShim.SelectAll();
            }

            else if (rCValid == false)
            {
                allValid = false;
                MessageBox.Show("Required Clearance be a non-negative number!",
                    "Invalid Required Clearance", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRequiredClearance.Focus();
                txtRequiredClearance.SelectAll();
            }

            return allValid;
        }

        private void DisplayResult(decimal rS)
        {
            lblReplacementShim.Text = rS.ToString("f2");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMeasuredClearance.Text = String.Empty;
            txtCurrentShim.Text = String.Empty;
            txtRequiredClearance.Text = String.Empty;
            lblReplacementShim.Text = String.Empty;
        }

        private void txtRequiredClearance_TextChanged(object sender, EventArgs e)
        {
            lblReplacementShim.Text = String.Empty;
        }

        private void txtMeasuredClearance_TextChanged(object sender, EventArgs e)
        {
            txtCurrentShim.Text = String.Empty;
            txtRequiredClearance.Text = String.Empty;
            lblReplacementShim.Text = String.Empty;
        }
    }
}

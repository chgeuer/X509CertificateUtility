namespace X509CertificateTool
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Security.Cryptography.X509Certificates;

    public partial class StoreSelectionForm : Form
    {
        public StoreSelectionForm()
        {
            InitializeComponent();
        }

        bool clicked_OK;

        IList<StoreLocation> _availableStoreLocations;
        IList<StoreName> _availableStoreNames;
        List<StoreLocation> _selectedStoreLocations = new List<StoreLocation>();
        List<StoreName> _selectedStoreNames = new List<StoreName>();        

        public StoreSelectionForm(
            IList<StoreLocation> availableStoreLocations, 
            IList<StoreName> availableStoreNames,
            ICollection<StoreLocation> selectedStoreLocations,
            ICollection<StoreName> selectedStoreNames,
            bool regexMatchCase)
            : this()
        {
            this.storeNamesCheckedListBox.Items.Clear();
            for (int i=0; i<availableStoreNames.Count; i++) 
            {
                StoreName sn = availableStoreNames[i];

                this.storeNamesCheckedListBox.Items.Add(sn);
                this.storeNamesCheckedListBox.SetItemChecked(i, 
                    selectedStoreNames.Contains(sn));
            }
            this._availableStoreNames = availableStoreNames;
            this._selectedStoreNames.AddRange(selectedStoreNames);

            this.storeLocationCheckedListBox.Items.Clear();
            for (int i = 0; i < availableStoreLocations.Count; i++)
            {
                StoreLocation sl = availableStoreLocations[i];
                this.storeLocationCheckedListBox.Items.Add(sl);
                this.storeLocationCheckedListBox.SetItemChecked(i,
                    selectedStoreLocations.Contains(sl));
            }
            this._availableStoreLocations = availableStoreLocations;
            this._selectedStoreLocations.AddRange(selectedStoreLocations);

            this.checkBoxRegexMatchCase.Checked = regexMatchCase;
        }

        private void setAllSelected(bool selection)
        {
            for (int i = 0; i < this.storeNamesCheckedListBox.Items.Count; i++)
            {
                this.storeNamesCheckedListBox.SetItemChecked(i, selection);
            }
            for (int i = 0; i < this.storeLocationCheckedListBox.Items.Count; i++)
            {
                this.storeLocationCheckedListBox.SetItemChecked(i, selection);
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            setAllSelected(true);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.clicked_OK = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.clicked_OK = false;
        }

        public IList<StoreLocation> StoreLocations
        {
            get
            {
                if (clicked_OK)
                {
                    List<StoreLocation> result = new List<StoreLocation>();

                    foreach (int sli in storeLocationCheckedListBox.CheckedIndices)
                    {
                        StoreLocation location = (StoreLocation)storeLocationCheckedListBox.Items[sli];
                        result.Add(location);
                    }

                    return result;
                }
                else
                {
                    List<StoreLocation> result = new List<StoreLocation>();
                    
                    foreach (StoreLocation storeLocation in _availableStoreLocations)
                    {
                        if (this._selectedStoreLocations.Contains(storeLocation))
                        {
                            result.Add(storeLocation);
                        }
                    }

                    return result;
                }
            }
        }

        public IList<StoreName> StoreNames
        {
            get
            {
                if (clicked_OK)
                {
                    List<StoreName> result = new List<StoreName>();

                    foreach (int sli in storeNamesCheckedListBox.CheckedIndices)
                    {
                        StoreName storeName = (StoreName)storeNamesCheckedListBox.Items[sli];
                        result.Add(storeName);
                    }

                    return result;
                }
                else
                {
                    List<StoreName> result = new List<StoreName>();

                    foreach (StoreName storeName in _availableStoreNames)
                    {
                        if (this._selectedStoreNames.Contains(storeName))
                        {
                            result.Add(storeName);
                        }
                    }

                    return result;
                }
            }
        }

        public bool RegexMatchCase 
        {
            get { return this.checkBoxRegexMatchCase.Checked; }
        }
    }
}
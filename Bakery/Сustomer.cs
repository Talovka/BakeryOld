using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Bakery.Entities;

namespace Bakery
{
    public partial class Сustomer : Form
    {
        private string check;
        private int residue;
        public Сustomer()
        {
            InitializeComponent();
            HideTabPage(client);
            HideTabPage(storekeeper);
            HideTabPage(cook);
            HideTabPage(admin);
            HideTabPage(breadFactory);
            HideTabPage(tabPageKiosk);
            HideTabPage(tabPageLog);
            changeUser.Enabled = false;
        }
        private void HideTabPage(TabPage tp)
        {
            if (Role.TabPages.Contains(tp))
                Role.TabPages.Remove(tp);
        }

        public void Authorization(string role)
        {

            HideTabPage(client);
            HideTabPage(storekeeper);
            HideTabPage(cook);
            HideTabPage(admin);
            HideTabPage(breadFactory);
            HideTabPage(tabPageKiosk);
            HideTabPage(tabPageLog);

            if (role == Constants.userStorekeeper)
            {
                changeUser.Enabled = true;
                input.Enabled = false;
                registration.Enabled = false;

                ShowTabPage(storekeeper);
                BoxСhangeStorekeeper.Items.Clear();
                BoxСhangeStorekeeper.Items.Add(Constants.add);
                BoxСhangeStorekeeper.Items.Add(Constants.delite);

                BoxBakeryWarehouseStorekeeper.Enabled = false;
                BoxProductStorekeeper.Enabled = false;
                textBoxQuantityStorekeeper.Enabled = false;
                buttonStorekeeper.Enabled = false;

                BoxBakeryWarehouseStorekeeper.DropDownStyle = ComboBoxStyle.DropDownList;
                BoxСhangeStorekeeper.DropDownStyle = ComboBoxStyle.DropDownList;
                BoxProductStorekeeper.DropDownStyle = ComboBoxStyle.DropDownList;

                BoxBakeryWarehouseStorekeeper.DataSource = DAL.GetBakerySearch(string.Empty);
                BoxBakeryStorekeeper.DataSource = DAL.GetBakerySearch(BoxBakeryStorekeeper.Text);
                BoxCategoryStorekeeper.DataSource = DAL.GetCategories(BoxCategoryStorekeeper.Text);
                dataGridViewStorekeeper.DataSource = DAL.GetWarehouse(BoxBakeryStorekeeper.Text, BoxCategoryStorekeeper.Text,
                    textBoxNameProductStorekeeper.Text);

            }
            if (role == Constants.userClient)
            {
                ShowTabPage(client);
                changeUser.Enabled = true;
                input.Enabled = false;
                registration.Enabled = false;
                comboBoxCategoryClient.Enabled = false;
                textPriceClient.Enabled = false;
                textNameClient.Enabled = false;
                textAddressClient.Enabled = false;
                comboBoxBakeryClient.Enabled = false;
                comboBoxBakeryClient.DataSource = DAL.GetBakerySearch(comboBoxBakeryClient.Text);
                comboBoxCategoryClient.DataSource = DAL.GetCategories(comboBoxCategoryClient.Text);
            }
            if (role == Constants.userCook)
            {
                ShowTabPage(cook);
                changeUser.Enabled = true;
                input.Enabled = false;
                registration.Enabled = false;

                comboBoxAddDelEditCook.Items.Add(Constants.add);
                comboBoxAddDelEditCook.Items.Add(Constants.delite);
                comboBoxAddDelEditCook.Items.Add(Constants.edit);
                comboBoxAddDelEditCook.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxCategoryCook.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxProductCook.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxCategoryCook.Enabled = false;
                comboBoxProductCook.Enabled = false;
                checkBoxCategoryCook.Enabled = false;
                checkBoxProductCook.Enabled = false;
                textBoxWeightCook.Enabled = false;
                textBoxFoodValueCook.Enabled = false;
                textBoxPriceCook.Enabled = false;
                buttonCook.Enabled = false;


                comboBoxCategoryCookSearch.DataSource = DAL.GetCategories(comboBoxCategoryClient.Text);
                comboBoxCategoryCook.DataSource = DAL.GetCategories(comboBoxCategoryClient.Text);
                comboBoxProductCookSearch.DataSource = DAL.GetProductName(comboBoxCategoryCookSearch.Text);
                dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                    textBoxPriceCookSearch.Text);
            }
            if (role == Constants.userAdmin)
            {
                ShowTabPage(tabPageLog);
                ShowTabPage(admin);
                changeUser.Enabled = true;
                input.Enabled = false;
                registration.Enabled = false;

                comboBoxAddDelEditOwnerAdmin.Items.Add(Constants.add);
                comboBoxAddDelEditOwnerAdmin.Items.Add(Constants.delite);
                comboBoxAddDelEditOwnerAdmin.Items.Add(Constants.edit);
                comboBoxAddDelEditOwnerAdmin.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxSurnameOwnerAdmin.Enabled = false;
                textBoxSurnameOwnerAdmin.Enabled = false;
                comboBoxFirsteNameOwnerAdmin.Enabled = false;
                textBoxFirsteNameOwnerAdmin.Enabled = false;
                comboBoxPatronymicOwnerAdmin.Enabled = false;
                checkBoxPatronymicOwnerAdmin.Enabled = false;
                textBoxPatronymicOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Enabled = false;
                dateTimePickerOwnerAdmin.Enabled = false;
                dateTimePickerOwnerAdmin.Value = DateTime.Now;

                checkBoxPatronymicOwnerAdmin.Text = "нет";

                comboBoxSurnameOwnerAdmin.DataSource = DAL.GetOwnerSurname(comboBoxSurnameOwnerAdmin.Text);
                comboBoxFirsteNameOwnerAdmin.DataSource = DAL.GetOwnerFirstName(comboBoxFirsteNameOwnerAdmin.Text);
                comboBoxPatronymicOwnerAdmin.DataSource = DAL.GetOwnerPatronymic(comboBoxPatronymicOwnerAdmin.Text);
                dataGridViewOwnerAdmin.DataSource = DAL.GetOwner(textBoxOwnerAdminSearch.Text);
                dateTimePickerLogC.Value = DateTime.Now;
                dateTimePickerLogDo.Value = DateTime.Now;
                dataGridViewLog.DataSource = DAL.GetLog();
            }
            if (role == Constants.userOwner)
            {
                ShowTabPage(breadFactory);
                ShowTabPage(tabPageKiosk);
                changeUser.Enabled = true;
                input.Enabled = false;
                registration.Enabled = false;

                comboBoxAddDelEditBakery.Items.Add(Constants.add);
                comboBoxAddDelEditBakery.Items.Add(Constants.delite);
                comboBoxAddDelEditBakery.Items.Add(Constants.edit);
                comboBoxAddDelEditBakery.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxNameBakery.Enabled = false;
                comboBoxNameBakery.Text = string.Empty;
                textBoxNameBakery.Enabled = false;
                textBoxNameBakery.Text = string.Empty;

                comboBoxAddressBakery.Enabled = false;
                comboBoxAddressBakery.Text = string.Empty;
                textBoxAddressBakery.Enabled = false;
                textBoxAddressBakery.Text = string.Empty;

                comboBoxPhoneBakery.Enabled = false;
                comboBoxPhoneBakery.Text = string.Empty;
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;

                buttonBakery.Enabled = false;

                dataGridViewBakery.DataSource = DAL.GetBreadFactory(textBoxBakerySearch.Text);
                comboBoxNameBakery.DataSource = DAL.GetBakeryName(comboBoxNameBakery.Text);

                comboBoxAddDelEditKiosk.Items.Add(Constants.add);
                comboBoxAddDelEditKiosk.Items.Add(Constants.delite);
                comboBoxAddDelEditKiosk.Items.Add(Constants.edit);
                comboBoxAddDelEditKiosk.DropDownStyle = ComboBoxStyle.DropDownList;

                comboBoxNameKiosk.Enabled = false;
                comboBoxNameKiosk.Text = string.Empty;
                textBoxNameKiosk.Enabled = false;
                textBoxNameKiosk.Text = string.Empty;

                comboBoxAddressKiosk.Enabled = false;
                comboBoxAddressKiosk.Text = string.Empty;
                textBoxAddressKiosk.Enabled = false;
                textBoxAddressKiosk.Text = string.Empty;

                comboBoxPhoneKiosk.Enabled = false;
                comboBoxPhoneKiosk.Text = string.Empty;
                textBoxPhoneKiosk.Enabled = false;
                textBoxPhoneKiosk.Text = string.Empty;

                comboBoxBakeryKiosk.Enabled = false;
                comboBoxBakeryKiosk.Text = string.Empty;
                comboBoxBakeryKioskEddit.Enabled = false;
                comboBoxBakeryKioskEddit.Text = string.Empty;

                comboBoxOwnerKiosk.Enabled = false;
                comboBoxOwnerKiosk.Text = string.Empty;
                comboBoxOwnerKioskEddit.Enabled = false;
                comboBoxOwnerKioskEddit.Text = string.Empty;

                comboBoxBakeryKiosk.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxBakeryKioskEddit.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxOwnerKioskEddit.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxOwnerKiosk.DropDownStyle = ComboBoxStyle.DropDownList;
                dataGridViewKiosk.DataSource = DAL.GetKiosksOwner(textBoxKioskSearch.Text);

            }
        }
        private void ShowTabPage(TabPage tp)
        {
            ShowTabPage(tp, Role.TabPages.Count);
        }

        private void ShowTabPage(TabPage tp, int index)
        {
            if (Role.TabPages.Contains(tp)) return;
            InsertTabPage(tp, index);
        }
        private void InsertTabPage(TabPage tabpage, int index)
        {
            if (index < 0 || index > Role.TabCount)
                throw new ArgumentException("Index out of Range.");
            Role.TabPages.Add(tabpage);
            if (index < Role.TabCount - 1)
                do
                {
                    SwapTabPages(tabpage, (Role.TabPages[Role.TabPages.IndexOf(tabpage) - 1]));
                }
                while (Role.TabPages.IndexOf(tabpage) != index);
            Role.SelectedTab = tabpage;
        }
        private void SwapTabPages(TabPage tp1, TabPage tp2)
        {
            if (Role.TabPages.Contains(tp1) == false || Role.TabPages.Contains(tp2) == false)
                throw new ArgumentException("TabPages must be in the TabControls TabPageCollection.");

            int Index1 = Role.TabPages.IndexOf(tp1);
            int Index2 = Role.TabPages.IndexOf(tp2);
            Role.TabPages[Index1] = tp2;
            Role.TabPages[Index2] = tp1;
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            Registration reg = new Registration();
            this.Hide();
            reg.ShowDialog();
            this.Show();
        }

        private void Input_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.ShowDialog();
            Authorization(log.Role);
            this.Show();
        }

        private void ChangeUser_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            this.Hide();
            log.ShowDialog();
            Authorization(log.Role);
            this.Show();
        }

        private void Product_Click(object sender, EventArgs e)
        {
            BindingList<Product> list = new BindingList<Product>(DAL.GetProductsClient(comboBoxCategoryClient.Text, textNameClient.Text, textPriceClient.Text));
            dataGridViewClient.DataSource = list;
            check = "Product";
            comboBoxCategoryClient.Enabled = true;
            textPriceClient.Enabled = true;
            textNameClient.Enabled = true;
            textAddressClient.Enabled = false;
            comboBoxBakeryClient.Enabled = false;
            textNameClient.Text = string.Empty;
            comboBoxCategoryClient.Text = string.Empty;
            textPriceClient.Text = string.Empty;
            textNameClient.Text = string.Empty;
            textAddressClient.Text = string.Empty;
            comboBoxBakeryClient.Text = string.Empty;
        }

        private void Kiosk_Click(object sender, EventArgs e)
        {
            BindingList<Kiosk> list = new BindingList<Kiosk>(DAL.GetKiosksClient(comboBoxBakeryClient.Text, textNameClient.Text, textAddressClient.Text));
            dataGridViewClient.DataSource = list;
            check = "Kiosk";
            comboBoxCategoryClient.Enabled = false;
            textPriceClient.Enabled = false;
            textNameClient.Enabled = true;
            textAddressClient.Enabled = true;
            comboBoxBakeryClient.Enabled = true;
            textNameClient.Text = string.Empty;
            comboBoxCategoryClient.Text = string.Empty;
            textPriceClient.Text = string.Empty;
            textNameClient.Text = string.Empty;
            textAddressClient.Text = string.Empty;
            comboBoxBakeryClient.Text = string.Empty;
        }

        private void Bakery_Click(object sender, EventArgs e)
        {
            BindingList<BreadFactory> list = new BindingList<BreadFactory>(DAL.GetBreadFactoryClient(textNameClient.Text, textAddressClient.Text));
            dataGridViewClient.DataSource = list;
            check = "Bakery";
            comboBoxCategoryClient.Enabled = false;
            textPriceClient.Enabled = false;
            textNameClient.Enabled = true;
            textAddressClient.Enabled = true;
            comboBoxBakeryClient.Enabled = false;
            textNameClient.Text = string.Empty;
            comboBoxCategoryClient.Text = string.Empty;
            textPriceClient.Text = string.Empty;
            textNameClient.Text = string.Empty;
            textAddressClient.Text = string.Empty;
            comboBoxBakeryClient.Text = string.Empty;
        }

        private void TextNameClient_TextChanged(object sender, EventArgs e)
        {
            if (check == "Product")
            {
                dataGridViewClient.DataSource = DAL.GetProductsClient(comboBoxCategoryClient.Text, textNameClient.Text, textPriceClient.Text);
            }
            else if (check == "Kiosk")
            {
                dataGridViewClient.DataSource = DAL.GetKiosksClient(comboBoxBakeryClient.Text, textNameClient.Text, textAddressClient.Text);
            }
            else if (check == "Bakery")
            {
                dataGridViewClient.DataSource = DAL.GetBreadFactoryClient(textNameClient.Text, textAddressClient.Text);
            }
        }

        private void TextAddressClient_TextChanged(object sender, EventArgs e)
        {
            if (check == "Bakery")
            {
                dataGridViewClient.DataSource = DAL.GetBreadFactoryClient(textNameClient.Text, textAddressClient.Text);
            }
            else if (check == "Kiosk")
            {
                dataGridViewClient.DataSource = DAL.GetKiosksClient(comboBoxBakeryClient.Text, textNameClient.Text, textAddressClient.Text);
            }
        }

        private void TextPriceClient_TextChanged(object sender, EventArgs e)
        {
            if (check == "Product")
            {
                dataGridViewClient.DataSource = DAL.GetProductsClient(comboBoxCategoryClient.Text, textNameClient.Text, textPriceClient.Text);
            }
        }

        private void ComboBoxBakeryClient_TextChanged(object sender, EventArgs e)
        {
            if (check == "Kiosk")
            {
                dataGridViewClient.DataSource = DAL.GetKiosksClient(comboBoxBakeryClient.Text, textNameClient.Text, textAddressClient.Text);
            }
        }

        private void ComboBoxCategoryClient_TextChanged(object sender, EventArgs e)
        {
            if (check == "Product")
            {
                dataGridViewClient.DataSource = DAL.GetProductsClient(comboBoxCategoryClient.Text, textNameClient.Text, textPriceClient.Text);
            }
        }

        private void BoxCategoryStorekeeper_TextChanged(object sender, EventArgs e)
        {
            dataGridViewStorekeeper.DataSource = DAL.GetWarehouse(BoxBakeryStorekeeper.Text, BoxCategoryStorekeeper.Text, textBoxNameProductStorekeeper.Text);
        }

        private void TextBoxNameProductStorekeeper_TextChanged(object sender, EventArgs e)
        {
            dataGridViewStorekeeper.DataSource = DAL.GetWarehouse(BoxBakeryStorekeeper.Text, BoxCategoryStorekeeper.Text, textBoxNameProductStorekeeper.Text);
        }

        private void BoxBakeryStorekeeper_TextChanged(object sender, EventArgs e)
        {
            dataGridViewStorekeeper.DataSource = DAL.GetWarehouse(BoxBakeryStorekeeper.Text, BoxCategoryStorekeeper.Text, textBoxNameProductStorekeeper.Text);
        }

        private void BoxСhangeStorekeeper_TextChanged(object sender, EventArgs e)
        {
            if (BoxСhangeStorekeeper.Text == string.Empty)
            {
                BoxProductStorekeeper.Text = string.Empty;
                textBoxQuantityStorekeeper.Text = string.Empty;
                BoxBakeryWarehouseStorekeeper.Text = string.Empty;

                BoxBakeryWarehouseStorekeeper.Enabled = false;
                BoxProductStorekeeper.Enabled = false;
                textBoxQuantityStorekeeper.Enabled = false;
                buttonStorekeeper.Text = string.Empty;

            }
            else if (BoxСhangeStorekeeper.Text == Constants.add || BoxСhangeStorekeeper.Text == Constants.delite)
            {
                BoxProductStorekeeper.Text = string.Empty;
                textBoxQuantityStorekeeper.Text = string.Empty;
                BoxBakeryWarehouseStorekeeper.Text = string.Empty;

                BoxBakeryWarehouseStorekeeper.Enabled = true;
                BoxProductStorekeeper.Enabled = false;
                textBoxQuantityStorekeeper.Enabled = false;
            }
            if (BoxСhangeStorekeeper.Text == Constants.add)
            {
                buttonStorekeeper.Text = Constants.add;
            }
            else if (BoxСhangeStorekeeper.Text == Constants.delite)
            {
                buttonStorekeeper.Text = Constants.delite;
            }
            buttonStorekeeper.Enabled = false;
        }

        private void BoxProductStorekeeper_TextChanged(object sender, EventArgs e)
        {
            residue = DAL.GetProductResidue(BoxBakeryWarehouseStorekeeper.Text, BoxProductStorekeeper.Text);
            if (BoxProductStorekeeper.Text == string.Empty)
            {

                textBoxQuantityStorekeeper.Text = string.Empty;


                textBoxQuantityStorekeeper.Enabled = false;
                buttonStorekeeper.Enabled = false;
            }
            else
            {
                textBoxQuantityStorekeeper.Text = string.Empty;

                textBoxQuantityStorekeeper.Enabled = true;
                buttonStorekeeper.Enabled = false;
                if (BoxСhangeStorekeeper.Text == Constants.delite)
                {
                    buttonStorekeeper.Enabled = true;
                    textBoxQuantityStorekeeper.Text = Convert.ToString(residue);
                }
            }
        }

        private void BoxBakeryWarehouseStorekeeper_TextChanged(object sender, EventArgs e)
        {
            if (BoxBakeryWarehouseStorekeeper.Text == string.Empty)
            {
                BoxProductStorekeeper.Text = string.Empty;
                textBoxQuantityStorekeeper.Text = string.Empty;

                BoxProductStorekeeper.Enabled = false;
                textBoxQuantityStorekeeper.Enabled = false;
            }
            else
            {
                BoxProductStorekeeper.Text = string.Empty;
                textBoxQuantityStorekeeper.Text = string.Empty;

                BoxProductStorekeeper.Enabled = true;
                textBoxQuantityStorekeeper.Enabled = false;
            }

            if (BoxСhangeStorekeeper.Text == Constants.add)
            {
                BoxProductStorekeeper.DataSource = DAL.GetAddProductWarehouse();
            }
            else
            {
                BoxProductStorekeeper.DataSource = DAL.GetDelProductWarehouse(BoxBakeryWarehouseStorekeeper.Text);
            }
            buttonStorekeeper.Enabled = false;
        }

        private void ButtonStorekeeper_Click(object sender, EventArgs e)
        {
            List<int> list = DAL.GetProductWarehouseId(BoxBakeryWarehouseStorekeeper.Text, BoxProductStorekeeper.Text);
            string stringValue = textBoxQuantityStorekeeper.Text;

            long integerValue;

            if (!long.TryParse(stringValue, out integerValue))
            {
                MessageBox.Show("Не удалось преобразовать " + stringValue + " в число!");
            }
            else
            {
                if (integerValue >= int.MaxValue)
                {
                    MessageBox.Show(" Достигнуто максимальное число " + int.MaxValue);
                }
                else if (integerValue <= 0)
                {
                    MessageBox.Show(" Измените число " + integerValue);
                }
                else
                {
                    if (BoxСhangeStorekeeper.Text == Constants.add)
                    {
                        if (DAL.GetAddProductWarehouseBool(BoxBakeryWarehouseStorekeeper.Text, BoxProductStorekeeper.Text) == true)
                        {
                            DAL.UpProductWarehouse(list[0], list[1], (int)(residue + integerValue));
                        }
                        else
                        {
                            DAL.AddProductWarehouse(list[0], list[1], Convert.ToInt32(integerValue));
                        }
                    }
                    else if (BoxСhangeStorekeeper.Text == Constants.delite)
                    {
                        if (residue - integerValue < 0)
                        {
                            MessageBox.Show(" На складе находится меньше товара (" + residue + "), чем указано в количестве (" + integerValue + ")");
                        }
                        else if (residue - integerValue == 0)
                        {
                            DAL.DelProductWarehouse(list[0], list[1]);
                        }
                        else if (residue - integerValue > 0)
                        {
                            DAL.UpProductWarehouse(list[0], list[1], (int)(residue - integerValue));
                        }
                    }
                    dataGridViewStorekeeper.DataSource = DAL.GetWarehouse(BoxBakeryStorekeeper.Text, BoxCategoryStorekeeper.Text, textBoxNameProductStorekeeper.Text);

                    BoxProductStorekeeper.Text = string.Empty;
                    textBoxQuantityStorekeeper.Text = string.Empty;
                    BoxBakeryWarehouseStorekeeper.Text = string.Empty;

                    BoxProductStorekeeper.Enabled = false;
                    textBoxQuantityStorekeeper.Enabled = false;
                }
            }
        }

        private void TextBoxQuantityStorekeeper_TextChanged(object sender, EventArgs e)
        {
            if (textBoxQuantityStorekeeper.Text == string.Empty)
            {
                buttonStorekeeper.Enabled = false;
            }
            else
            {
                buttonStorekeeper.Enabled = true;
            }
        }

        private void ComboBoxCategoryCookSearch_TextChanged(object sender, EventArgs e)
        {
            comboBoxProductCookSearch.DataSource = DAL.GetProductName(comboBoxCategoryCookSearch.Text);
            dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                textBoxPriceCookSearch.Text);
        }

        private void ComboBoxProductCookSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                textBoxPriceCookSearch.Text);
        }

        private void TextBoxPriceCookSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                textBoxPriceCookSearch.Text);
        }

        private void ComboBoxAddDelEditCook_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddDelEditCook.Text == Constants.add)
            {
                buttonCook.Text = Constants.add;
                comboBoxCategoryCook.Enabled = true;
                comboBoxProductCook.Enabled = false;
                checkBoxCategoryCook.Enabled = true;
                checkBoxProductCook.Enabled = false;
                textBoxWeightCook.Enabled = false;
                textBoxFoodValueCook.Enabled = false;
                textBoxPriceCook.Enabled = false;
                buttonCook.Enabled = false;
                checkBoxCategoryCook.Checked = false;
                checkBoxProductCook.Checked = false;

                checkBoxCategoryCook.Text = "Доб. новую категорию";
                checkBoxProductCook.Text = "Доб. новый продукт";
                comboBoxCategoryCook.Text = string.Empty;
                comboBoxProductCook.Text = string.Empty;
                textBoxWeightCook.Text = string.Empty;
                textBoxFoodValueCook.Text = string.Empty;
                textBoxPriceCook.Text = string.Empty;

                checkBoxProductCook.Checked = false;
            }
            else if (comboBoxAddDelEditCook.Text == Constants.delite)
            {
                buttonCook.Text = Constants.delite;

                comboBoxCategoryCook.Enabled = true;
                comboBoxProductCook.Enabled = false;
                checkBoxCategoryCook.Enabled = true;
                checkBoxProductCook.Enabled = false;
                textBoxWeightCook.Enabled = false;
                textBoxFoodValueCook.Enabled = false;
                textBoxPriceCook.Enabled = false;
                buttonCook.Enabled = false;
                checkBoxCategoryCook.Checked = false;
                checkBoxProductCook.Checked = false;

                checkBoxCategoryCook.Text = "Удалить категорию";
                checkBoxProductCook.Text = string.Empty;
                comboBoxCategoryCook.Text = string.Empty;
                comboBoxProductCook.Text = string.Empty;
                textBoxWeightCook.Text = string.Empty;
                textBoxFoodValueCook.Text = string.Empty;
                textBoxPriceCook.Text = string.Empty;

                comboBoxCategoryCook.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxProductCook.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            else if (comboBoxAddDelEditCook.Text == Constants.edit)
            {
                buttonCook.Text = Constants.edit;

                checkBoxCategoryCook.Text = string.Empty;
                checkBoxProductCook.Text = string.Empty;
                comboBoxCategoryCook.Text = string.Empty;
                comboBoxProductCook.Text = string.Empty;
                textBoxWeightCook.Text = string.Empty;
                textBoxFoodValueCook.Text = string.Empty;
                textBoxPriceCook.Text = string.Empty;

                checkBoxCategoryCook.Enabled = false;
                checkBoxProductCook.Enabled = false;
                comboBoxCategoryCook.Enabled = true;
                comboBoxProductCook.Enabled = false;
                textBoxWeightCook.Enabled = false;
                textBoxFoodValueCook.Enabled = false;
                textBoxPriceCook.Enabled = false;
                buttonCook.Enabled = false;
                checkBoxCategoryCook.Checked = false;
                checkBoxProductCook.Checked = false;

                comboBoxCategoryCook.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxProductCook.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void CheckBoxCategoryCook_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCategoryCook.Checked == true && comboBoxAddDelEditCook.Text == Constants.add)
            {
                comboBoxCategoryCook.DropDownStyle = ComboBoxStyle.Simple;
                comboBoxProductCook.DropDownStyle = ComboBoxStyle.Simple;
                checkBoxProductCook.Enabled = false;
                checkBoxProductCook.Checked = false;
            }
            else if (checkBoxCategoryCook.Checked == false && comboBoxAddDelEditCook.Text == Constants.add)
            {
                comboBoxCategoryCook.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxProductCook.DropDownStyle = ComboBoxStyle.DropDownList;
                if (comboBoxCategoryCook.Text != string.Empty)
                    checkBoxProductCook.Enabled = true;
            }
            else if (checkBoxCategoryCook.Checked == true && comboBoxAddDelEditCook.Text == Constants.delite &&
                comboBoxCategoryCook.Text != string.Empty)
            {
                buttonCook.Enabled = true;
                comboBoxProductCook.Text = string.Empty;
                comboBoxProductCook.Enabled = false;
            }
            else if (checkBoxCategoryCook.Checked == false && comboBoxAddDelEditCook.Text == Constants.delite)
            {
                buttonCook.Enabled = false;
                comboBoxProductCook.Enabled = true;
            }

        }

        private void CheckBoxProductCook_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProductCook.Checked == true)
            {
                comboBoxProductCook.DropDownStyle = ComboBoxStyle.Simple;
            }
            else
            {
                comboBoxProductCook.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }

        private void ComboBoxProductCook_TextChanged(object sender, EventArgs e)
        {
            textBoxWeightCook.Text = string.Empty;
            textBoxFoodValueCook.Text = string.Empty;
            textBoxPriceCook.Text = string.Empty;

            if (comboBoxProductCook.Text == string.Empty)
            {
                textBoxWeightCook.Enabled = false;
                textBoxFoodValueCook.Enabled = false;
                textBoxPriceCook.Enabled = false;
                if (comboBoxAddDelEditCook.Text != Constants.delite && checkBoxCategoryCook.Checked != true)
                    buttonCook.Enabled = false;
            }
            else if (comboBoxAddDelEditCook.Text != Constants.delite)
            {
                textBoxWeightCook.Enabled = true;
                textBoxFoodValueCook.Enabled = true;
                textBoxPriceCook.Enabled = true;

                buttonCook.Enabled = true;
            }
            else if (comboBoxAddDelEditCook.Text == Constants.delite)
            {
                buttonCook.Enabled = true;
            }

        }

        private void ComboBoxCategoryCook_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoryCook.Text == string.Empty)
            {
                comboBoxProductCook.Enabled = false;
                checkBoxProductCook.Enabled = false;
                if (checkBoxCategoryCook.Checked == true)
                    buttonCook.Enabled = false;
            }
            else if (comboBoxAddDelEditCook.Text == Constants.add || comboBoxAddDelEditCook.Text == Constants.edit ||
                (comboBoxAddDelEditCook.Text == Constants.delite && checkBoxCategoryCook.Checked == false))
            {
                comboBoxProductCook.DataSource = DAL.GetProductName(comboBoxCategoryCook.Text);
                comboBoxProductCook.Enabled = true;
                if (comboBoxAddDelEditCook.Text == Constants.add)
                {
                    comboBoxProductCook.DataSource = DAL.GetProductName(string.Empty);
                    checkBoxProductCook.Enabled = true;
                }
            }
            else if (checkBoxCategoryCook.Checked == true && comboBoxAddDelEditCook.Text == Constants.delite)
            {
                buttonCook.Enabled = true;
            }
            else if (checkBoxCategoryCook.Checked == false && comboBoxAddDelEditCook.Text == Constants.delite)
            {
                buttonCook.Enabled = false;
            }
        }

        private void ButtonCook_Click(object sender, EventArgs e)
        {
            string stringCategory = comboBoxCategoryCook.Text.Trim();
            string stringProduct = comboBoxProductCook.Text.Trim();
            string stringWeight = textBoxWeightCook.Text.Trim();
            string stringFoodValue = textBoxFoodValueCook.Text.Trim();
            string stringPrice = textBoxPriceCook.Text.Trim();
            int numberWeight;
            int numberFoodValue;
            decimal numberPrice;

            if (comboBoxAddDelEditCook.Text != Constants.delite)
            {
                if (stringCategory == string.Empty | stringProduct == string.Empty | stringWeight == string.Empty |
                stringFoodValue == string.Empty | stringPrice == string.Empty)
                {
                    MessageBox.Show("Заполните все поля", "Сообщение");
                }
                else if (int.TryParse(stringWeight, out numberWeight) && (int.TryParse(stringFoodValue, out numberFoodValue)) &&
                (decimal.TryParse(stringPrice, out numberPrice)))
                {
                    if (numberWeight <= 0 || numberFoodValue <= 0 || numberPrice <= 0)
                    {
                        MessageBox.Show("Укажите числа больше 0", "Сообщение");
                    }
                    else
                    {
                        if (comboBoxAddDelEditCook.Text == Constants.add)
                        {
                            if (checkBoxCategoryCook.Checked == true && DAL.boolCategoryCheck(comboBoxCategoryCook.Text) == true)
                            {
                                MessageBox.Show("Данная категория " + comboBoxCategoryCook.Text + " уже существует", "Сообщение");
                            }

                            else
                            {
                                if (checkBoxCategoryCook.Checked == true && DAL.boolCategoryCheck(comboBoxCategoryCook.Text) == false)
                                {
                                    DAL.AddCategory(comboBoxCategoryCook.Text);
                                }
                                if (DAL.boolProductCategoryCheck(comboBoxCategoryCook.Text, comboBoxProductCook.Text))
                                {
                                    MessageBox.Show("Данный продукт " + comboBoxCategoryCook.Text + " уже существует", "Сообщение");
                                }
                                else
                                {
                                    int categoryId = DAL.GetCategoryId(stringCategory);
                                    DAL.AddProduct(categoryId, stringProduct, numberWeight, numberFoodValue, numberPrice);
                                }
                            }
                            buttonCook.Enabled = false;
                            comboBoxCategoryCook.DataSource = DAL.GetCategories(comboBoxCategoryClient.Text);
                            comboBoxProductCook.DataSource = DAL.GetProductName(comboBoxCategoryCook.Text);
                            comboBoxCategoryCook.Text = string.Empty;
                            comboBoxProductCook.Text = string.Empty;
                            dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                            textBoxPriceCookSearch.Text);
                        }
                        else if (comboBoxAddDelEditCook.Text == Constants.edit)
                        {
                            List<int> list = DAL.GetProductCategoryID(stringCategory, stringProduct);
                            DAL.UpProduct(list[0], list[1], numberWeight, numberFoodValue, numberPrice);
                            dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                            textBoxPriceCookSearch.Text);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Для 'Массы', 'Энерг. ценности' и 'Цены' введите число", "Сообщение");
                }
            }
            else
            {
                if (comboBoxAddDelEditCook.Text == Constants.delite)
                {
                    if (checkBoxCategoryCook.Checked == false)
                    {
                        List<int> list = DAL.GetProductCategoryID(stringCategory, stringProduct);
                        DAL.DelProduct(list[0], list[1]);
                        bool isCategory = DAL.boolCategory(stringCategory);
                        if (isCategory == false)
                        {
                            int categoryId = DAL.GetCategoryId(stringCategory);
                            DAL.DelCategory(categoryId);
                        }
                        dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                    textBoxPriceCookSearch.Text);
                    }
                    else
                    {
                        int categoryId = DAL.GetCategoryId(stringCategory);
                        DAL.DelCategory(categoryId);
                        dataGridViewCook.DataSource = DAL.GetProductsClient(comboBoxCategoryCookSearch.Text, comboBoxProductCookSearch.Text,
                    textBoxPriceCookSearch.Text);
                    }
                    buttonCook.Enabled = false;
                    comboBoxCategoryCook.DataSource = DAL.GetCategories(comboBoxCategoryClient.Text);
                    comboBoxProductCook.DataSource = DAL.GetProductName(comboBoxCategoryCook.Text);
                    comboBoxCategoryCook.Text = string.Empty;
                    comboBoxProductCook.Text = string.Empty;

                }
            }
        }

        private void TextBoxOwnerAdminSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewOwnerAdmin.DataSource = DAL.GetOwner(textBoxOwnerAdminSearch.Text);
        }

        private void ComboBoxAddDelEditOwnerAdmin_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddDelEditOwnerAdmin.Text == Constants.add)
            {
                comboBoxSurnameOwnerAdmin.Enabled = true;
                comboBoxSurnameOwnerAdmin.DropDownStyle = ComboBoxStyle.Simple;
                comboBoxSurnameOwnerAdmin.Text = string.Empty;
                textBoxSurnameOwnerAdmin.Enabled = false;
                textBoxSurnameOwnerAdmin.Text = string.Empty;

                comboBoxFirsteNameOwnerAdmin.Enabled = true;
                comboBoxFirsteNameOwnerAdmin.DropDownStyle = ComboBoxStyle.Simple;
                comboBoxFirsteNameOwnerAdmin.Text = string.Empty;
                textBoxFirsteNameOwnerAdmin.Enabled = false;
                textBoxFirsteNameOwnerAdmin.Text = string.Empty;

                comboBoxPatronymicOwnerAdmin.Enabled = true;
                comboBoxPatronymicOwnerAdmin.DropDownStyle = ComboBoxStyle.Simple;
                comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                checkBoxPatronymicOwnerAdmin.Enabled = true;
                checkBoxPatronymicOwnerAdmin.Checked = false;
                textBoxPatronymicOwnerAdmin.Enabled = false;
                textBoxPatronymicOwnerAdmin.Text = string.Empty;

                dateTimePickerOwnerAdmin.Enabled = true;
                buttonOwnerAdmin.Enabled = true;
                buttonOwnerAdmin.Text = Constants.add;
            }
            else if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite)
            {
                comboBoxSurnameOwnerAdmin.Enabled = true;
                comboBoxSurnameOwnerAdmin.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxSurnameOwnerAdmin.Text = string.Empty;
                textBoxSurnameOwnerAdmin.Enabled = false;
                textBoxSurnameOwnerAdmin.Text = string.Empty;

                comboBoxFirsteNameOwnerAdmin.Enabled = false;
                comboBoxFirsteNameOwnerAdmin.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxFirsteNameOwnerAdmin.Text = string.Empty;
                textBoxFirsteNameOwnerAdmin.Enabled = false;
                textBoxFirsteNameOwnerAdmin.Text = string.Empty;

                comboBoxPatronymicOwnerAdmin.Enabled = false;
                comboBoxPatronymicOwnerAdmin.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                checkBoxPatronymicOwnerAdmin.Enabled = false;
                checkBoxPatronymicOwnerAdmin.Checked = false;
                textBoxPatronymicOwnerAdmin.Enabled = false;
                textBoxPatronymicOwnerAdmin.Text = string.Empty;

                dateTimePickerOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Text = Constants.delite;

                comboBoxSurnameOwnerAdmin.DataSource = DAL.GetOwnerSurname(comboBoxSurnameOwnerAdmin.Text);
                comboBoxFirsteNameOwnerAdmin.DataSource = DAL.GetOwnerFirstName(comboBoxFirsteNameOwnerAdmin.Text);
                comboBoxPatronymicOwnerAdmin.DataSource = DAL.GetOwnerPatronymic(comboBoxPatronymicOwnerAdmin.Text);
            }
            else if (comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
            {
                comboBoxSurnameOwnerAdmin.Enabled = true;
                comboBoxSurnameOwnerAdmin.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxSurnameOwnerAdmin.Text = string.Empty;
                textBoxSurnameOwnerAdmin.Enabled = false;
                textBoxSurnameOwnerAdmin.Text = string.Empty;

                comboBoxFirsteNameOwnerAdmin.Enabled = false;
                comboBoxFirsteNameOwnerAdmin.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxFirsteNameOwnerAdmin.Text = string.Empty;
                textBoxFirsteNameOwnerAdmin.Enabled = false;
                textBoxFirsteNameOwnerAdmin.Text = string.Empty;

                comboBoxPatronymicOwnerAdmin.Enabled = false;
                comboBoxPatronymicOwnerAdmin.DropDownStyle = ComboBoxStyle.DropDown;
                comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                checkBoxPatronymicOwnerAdmin.Enabled = false;
                checkBoxPatronymicOwnerAdmin.Checked = false;
                textBoxPatronymicOwnerAdmin.Enabled = false;
                textBoxPatronymicOwnerAdmin.Text = string.Empty;

                dateTimePickerOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Text = Constants.edit;
                comboBoxSurnameOwnerAdmin.DataSource = DAL.GetOwnerSurname(comboBoxSurnameOwnerAdmin.Text);
                comboBoxFirsteNameOwnerAdmin.DataSource = DAL.GetOwnerFirstName(comboBoxFirsteNameOwnerAdmin.Text);
                comboBoxPatronymicOwnerAdmin.DataSource = DAL.GetOwnerPatronymic(comboBoxPatronymicOwnerAdmin.Text);
            }
        }

        private void ComboBoxSurnameOwnerAdmin_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite || comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
            {
                if (comboBoxSurnameOwnerAdmin.Text == string.Empty)
                {
                    comboBoxFirsteNameOwnerAdmin.Enabled = false;
                    comboBoxFirsteNameOwnerAdmin.Text = string.Empty;
                }
                else
                {
                    comboBoxFirsteNameOwnerAdmin.Enabled = true;
                    comboBoxFirsteNameOwnerAdmin.Text = string.Empty;
                }
                comboBoxPatronymicOwnerAdmin.Enabled = false;
                comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                checkBoxPatronymicOwnerAdmin.Enabled = false;
                checkBoxPatronymicOwnerAdmin.Checked = false;
                textBoxPatronymicOwnerAdmin.Enabled = false;
                textBoxPatronymicOwnerAdmin.Text = string.Empty;

                dateTimePickerOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Enabled = false;
            }

            if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite)
            {
                textBoxSurnameOwnerAdmin.Enabled = false;
                textBoxSurnameOwnerAdmin.Text = string.Empty;
            }
            else if (comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
            {
                if (comboBoxSurnameOwnerAdmin.Text == string.Empty)
                {
                    textBoxSurnameOwnerAdmin.Enabled = false;
                    textBoxSurnameOwnerAdmin.Text = string.Empty;
                }
                else
                {
                    textBoxSurnameOwnerAdmin.Enabled = true;
                    textBoxSurnameOwnerAdmin.Text = string.Empty;
                }
            }
            comboBoxFirsteNameOwnerAdmin.DataSource = DAL.GetOwnerFirstName(comboBoxSurnameOwnerAdmin.Text);
        }
        private void ComboBoxFirsteNameOwnerAdmin_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite || comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
            {
                if (comboBoxFirsteNameOwnerAdmin.Text == string.Empty)
                {
                    comboBoxPatronymicOwnerAdmin.Enabled = false;
                    comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                    checkBoxPatronymicOwnerAdmin.Enabled = false;
                    checkBoxPatronymicOwnerAdmin.Checked = false;
                    textBoxPatronymicOwnerAdmin.Enabled = false;
                    textBoxPatronymicOwnerAdmin.Text = string.Empty;
                }
                else
                {
                    comboBoxPatronymicOwnerAdmin.Enabled = true;
                    comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                    checkBoxPatronymicOwnerAdmin.Enabled = true;
                    textBoxPatronymicOwnerAdmin.Enabled = false;
                }
                checkBoxPatronymicOwnerAdmin.Checked = false;
                dateTimePickerOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Enabled = false;
            }

            if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite)
            {
                textBoxFirsteNameOwnerAdmin.Enabled = false;
                textBoxFirsteNameOwnerAdmin.Text = string.Empty;
            }
            else if (comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
            {
                if (comboBoxSurnameOwnerAdmin.Text == string.Empty)
                {
                    textBoxFirsteNameOwnerAdmin.Enabled = false;
                    textBoxFirsteNameOwnerAdmin.Text = string.Empty;
                }
                else
                {
                    textBoxFirsteNameOwnerAdmin.Enabled = true;
                }
            }
            comboBoxPatronymicOwnerAdmin.DataSource = DAL.GetOwnerSurnameFirstName(comboBoxSurnameOwnerAdmin.Text, comboBoxFirsteNameOwnerAdmin.Text);
        }
        private void ComboBoxPatronymicOwnerAdmin_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite || comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
            {
                if (comboBoxPatronymicOwnerAdmin.Text == string.Empty)
                {
                    dateTimePickerOwnerAdmin.Enabled = false;
                    buttonOwnerAdmin.Enabled = false;
                }
                else
                {
                    dateTimePickerOwnerAdmin.Enabled = true;
                    buttonOwnerAdmin.Enabled = true;
                }
            }
            if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite)
            {
                textBoxPatronymicOwnerAdmin.Enabled = false;
                textBoxPatronymicOwnerAdmin.Text = string.Empty;
            }
            else if (comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
            {
                if (comboBoxPatronymicOwnerAdmin.Text == string.Empty)
                {
                    textBoxPatronymicOwnerAdmin.Enabled = false;
                    textBoxPatronymicOwnerAdmin.Text = string.Empty;
                }
                else
                {
                    if (checkBoxPatronymicOwnerAdmin.Checked == false)
                    {
                        textBoxPatronymicOwnerAdmin.Enabled = true;
                    }
                    else
                    {
                        textBoxPatronymicOwnerAdmin.Enabled = false;
                    }
                }
            }
        }
        private void ButtonOwnerAdmin_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Year <= dateTimePickerOwnerAdmin.Value.Year + 18)
            {
                MessageBox.Show("Укажите день рождения раньше " + (DateTime.Now.Year - 18) + " года", "Сообщение");
            }
            else if (comboBoxSurnameOwnerAdmin.Text.Trim() == string.Empty || comboBoxFirsteNameOwnerAdmin.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Введите данные для всех полей", "Сообщение");
            }
            else
            {
                if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite || comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
                {
                    if (DAL.GetOwnerSurnameFirstNamePatronymic(comboBoxSurnameOwnerAdmin.Text, comboBoxFirsteNameOwnerAdmin.Text,
                   comboBoxPatronymicOwnerAdmin.Text, dateTimePickerOwnerAdmin.Value) == 0)
                    {
                        MessageBox.Show("Ни один владелец не найден (возможно вы не задали день рождения)", "Сообщение");
                    }
                    else
                    {
                        if (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite)
                        {
                            DAL.DelOwner(DAL.GetOwnerSurnameFirstNamePatronymic(comboBoxSurnameOwnerAdmin.Text, comboBoxFirsteNameOwnerAdmin.Text,
                    comboBoxPatronymicOwnerAdmin.Text, dateTimePickerOwnerAdmin.Value));
                        }
                        else if (comboBoxAddDelEditOwnerAdmin.Text == Constants.edit)
                        {
                            if (textBoxSurnameOwnerAdmin.Text == string.Empty)
                            {
                                textBoxSurnameOwnerAdmin.Text = comboBoxSurnameOwnerAdmin.Text;
                            }
                            if (textBoxFirsteNameOwnerAdmin.Text == string.Empty)
                            {
                                textBoxFirsteNameOwnerAdmin.Text = comboBoxFirsteNameOwnerAdmin.Text;
                            }
                            if (textBoxPatronymicOwnerAdmin.Text == string.Empty && checkBoxPatronymicOwnerAdmin.Checked == false)
                            {
                                textBoxPatronymicOwnerAdmin.Text = comboBoxPatronymicOwnerAdmin.Text;
                            }
                            DAL.UpProduct(DAL.GetOwnerSurnameFirstNamePatronymic(comboBoxSurnameOwnerAdmin.Text, comboBoxFirsteNameOwnerAdmin.Text,
                   comboBoxPatronymicOwnerAdmin.Text, dateTimePickerOwnerAdmin.Value), textBoxSurnameOwnerAdmin.Text, textBoxFirsteNameOwnerAdmin.Text,
                   textBoxPatronymicOwnerAdmin.Text);

                        }
                    }
                }
                else if (comboBoxAddDelEditOwnerAdmin.Text == Constants.add)
                {
                    if (DAL.GetOwnerSurnameFirstNamePatronymic(comboBoxSurnameOwnerAdmin.Text, comboBoxFirsteNameOwnerAdmin.Text,
                   comboBoxPatronymicOwnerAdmin.Text, dateTimePickerOwnerAdmin.Value) != 0)
                    {
                        MessageBox.Show("Данный владелец уже существует в базе данных", "Сообщение");
                    }
                    else
                    {
                        DAL.AddOwner(comboBoxSurnameOwnerAdmin.Text, comboBoxFirsteNameOwnerAdmin.Text,
                            comboBoxPatronymicOwnerAdmin.Text, dateTimePickerOwnerAdmin.Value);
                    }
                }
            }
            dataGridViewOwnerAdmin.DataSource = DAL.GetOwner(textBoxOwnerAdminSearch.Text);
            comboBoxSurnameOwnerAdmin.DataSource = DAL.GetOwnerSurname(comboBoxSurnameOwnerAdmin.Text);
            comboBoxFirsteNameOwnerAdmin.DataSource = DAL.GetOwnerFirstName(comboBoxFirsteNameOwnerAdmin.Text);
            comboBoxPatronymicOwnerAdmin.DataSource = DAL.GetOwnerPatronymic(comboBoxPatronymicOwnerAdmin.Text);
        }
        private void CheckBoxPatronymicOwnerAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPatronymicOwnerAdmin.Checked == false && (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite))
            {
                comboBoxPatronymicOwnerAdmin.Enabled = true;
                dateTimePickerOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Enabled = false;
            }
            else if (checkBoxPatronymicOwnerAdmin.Checked == false && (comboBoxAddDelEditOwnerAdmin.Text == Constants.add))
            {
                comboBoxPatronymicOwnerAdmin.Enabled = true;
            }
            else if (checkBoxPatronymicOwnerAdmin.Checked == true && (comboBoxAddDelEditOwnerAdmin.Text == Constants.delite ||
                comboBoxAddDelEditOwnerAdmin.Text == Constants.add))
            {
                comboBoxPatronymicOwnerAdmin.Enabled = false;
                comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                dateTimePickerOwnerAdmin.Enabled = true;
                buttonOwnerAdmin.Enabled = true;
            }
            else if (checkBoxPatronymicOwnerAdmin.Checked == true && (comboBoxAddDelEditOwnerAdmin.Text == Constants.edit))
            {
                comboBoxPatronymicOwnerAdmin.Enabled = false;
                comboBoxPatronymicOwnerAdmin.Text = string.Empty;
                textBoxPatronymicOwnerAdmin.Enabled = true;
                textBoxPatronymicOwnerAdmin.Text = string.Empty;
                dateTimePickerOwnerAdmin.Enabled = true;
                buttonOwnerAdmin.Enabled = true;
            }
            else if (checkBoxPatronymicOwnerAdmin.Checked == false && (comboBoxAddDelEditOwnerAdmin.Text == Constants.edit))
            {
                comboBoxPatronymicOwnerAdmin.Enabled = true;
                textBoxPatronymicOwnerAdmin.Enabled = false;
                dateTimePickerOwnerAdmin.Enabled = false;
                buttonOwnerAdmin.Enabled = false;
            }
        }

        private void TextBoxBakerySearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewBakery.DataSource = DAL.GetBreadFactory(textBoxBakerySearch.Text);
        }

        private void ComboBoxAddDelEditBakery_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddDelEditBakery.Text == Constants.add)
            {
                comboBoxNameBakery.Enabled = true;
                comboBoxNameBakery.Text = string.Empty;
                textBoxNameBakery.Enabled = false;
                textBoxNameBakery.Text = string.Empty;
                comboBoxNameBakery.DropDownStyle = ComboBoxStyle.Simple;

                comboBoxAddressBakery.Enabled = true;
                comboBoxAddressBakery.Text = string.Empty;
                textBoxAddressBakery.Enabled = false;
                textBoxAddressBakery.Text = string.Empty;
                comboBoxAddressBakery.DropDownStyle = ComboBoxStyle.Simple;

                comboBoxPhoneBakery.Enabled = true;
                comboBoxPhoneBakery.Text = string.Empty;
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;
                comboBoxPhoneBakery.DropDownStyle = ComboBoxStyle.Simple;

                buttonBakery.Enabled = true;
                buttonBakery.Text = Constants.add;
            }
            else if (comboBoxAddDelEditBakery.Text == Constants.delite)
            {
                comboBoxNameBakery.Enabled = true;
                comboBoxNameBakery.Text = string.Empty;
                textBoxNameBakery.Enabled = false;
                textBoxNameBakery.Text = string.Empty;
                comboBoxNameBakery.DropDownStyle = ComboBoxStyle.DropDown;

                comboBoxAddressBakery.Enabled = false;
                comboBoxAddressBakery.Text = string.Empty;
                textBoxAddressBakery.Enabled = false;
                textBoxAddressBakery.Text = string.Empty;
                comboBoxAddressBakery.DropDownStyle = ComboBoxStyle.DropDown;

                comboBoxPhoneBakery.Enabled = false;
                comboBoxPhoneBakery.Text = string.Empty;
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;
                comboBoxPhoneBakery.DropDownStyle = ComboBoxStyle.DropDown;

                buttonBakery.Enabled = false;
                buttonBakery.Text = Constants.delite;
            }
            else if (comboBoxAddDelEditBakery.Text == Constants.edit)
            {
                comboBoxNameBakery.Enabled = true;
                comboBoxNameBakery.Text = string.Empty;
                textBoxNameBakery.Enabled = false;
                textBoxNameBakery.Text = string.Empty;
                comboBoxNameBakery.DropDownStyle = ComboBoxStyle.DropDown;

                comboBoxAddressBakery.Enabled = false;
                comboBoxAddressBakery.Text = string.Empty;
                textBoxAddressBakery.Enabled = false;
                textBoxAddressBakery.Text = string.Empty;
                comboBoxAddressBakery.DropDownStyle = ComboBoxStyle.DropDown;

                comboBoxPhoneBakery.Enabled = false;
                comboBoxPhoneBakery.Text = string.Empty;
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;
                comboBoxPhoneBakery.DropDownStyle = ComboBoxStyle.DropDown;

                buttonBakery.Enabled = false;
                buttonBakery.Text = Constants.edit;
            }
            comboBoxNameBakery.DataSource = DAL.GetBakeryName(comboBoxNameBakery.Text);
        }

        private void ComboBoxNameBakery_TextChanged(object sender, EventArgs e)
        {

            if (comboBoxAddDelEditBakery.Text == Constants.delite)
            {
                if (comboBoxNameBakery.Text == string.Empty)
                    buttonBakery.Enabled = false;
                else buttonBakery.Enabled = true;

                comboBoxAddressBakery.Enabled = false;
                comboBoxAddressBakery.Text = string.Empty;
                textBoxAddressBakery.Enabled = false;
                textBoxAddressBakery.Text = string.Empty;

                comboBoxPhoneBakery.Enabled = false;
                comboBoxPhoneBakery.Text = string.Empty;
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;
            }
            else if (comboBoxAddDelEditBakery.Text == Constants.edit)
            {
                if (comboBoxNameBakery.Text == string.Empty)
                {
                    comboBoxAddressBakery.Enabled = false;
                    textBoxNameBakery.Enabled = false;
                    textBoxNameBakery.Text = string.Empty;
                }
                else
                {
                    comboBoxAddressBakery.Enabled = true;
                    textBoxNameBakery.Enabled = true;
                }
                comboBoxAddressBakery.Text = string.Empty;
                textBoxAddressBakery.Enabled = false;
                textBoxAddressBakery.Text = string.Empty;

                comboBoxPhoneBakery.Enabled = false;
                comboBoxPhoneBakery.Text = string.Empty;
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;
                buttonBakery.Enabled = false;
                comboBoxAddressBakery.DataSource = DAL.GetBakeryAddress(comboBoxNameBakery.Text);
            }
        }

        private void ComboBoxAddressBakery_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddDelEditBakery.Text == Constants.edit)
            {
                if (comboBoxAddressBakery.Text == string.Empty)
                {
                    comboBoxPhoneBakery.Enabled = false;
                    textBoxAddressBakery.Enabled = false;
                    textBoxAddressBakery.Text = string.Empty;
                }
                else
                {
                    comboBoxPhoneBakery.Enabled = true;
                    textBoxAddressBakery.Enabled = true;
                }
                comboBoxPhoneBakery.Text = string.Empty;
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;
                buttonBakery.Enabled = false;
                comboBoxPhoneBakery.DataSource = DAL.GetBreadFactoryPhone(comboBoxNameBakery.Text, comboBoxAddressBakery.Text);
            }
        }

        private void ComboBoxPhoneBakery_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxAddressBakery.Text == string.Empty)
            {
                textBoxPhoneBakery.Enabled = false;
                textBoxPhoneBakery.Text = string.Empty;
                buttonBakery.Enabled = false;
            }
            else
            {
                if (comboBoxAddDelEditBakery.Text == Constants.edit)
                {
                    textBoxPhoneBakery.Enabled = true;
                    buttonBakery.Enabled = true;
                }
            }
        }

        private void ButtonBakery_Click(object sender, EventArgs e)
        {
            long numberPhone;

            if (comboBoxAddDelEditBakery.Text == Constants.edit || comboBoxAddDelEditBakery.Text == Constants.delite)
            {
                if (DAL.GetBakeryNameId(comboBoxNameBakery.Text) == 0)
                {
                    MessageBox.Show("Завод не найден", "Сообщение");
                }
                else
                {
                    if (comboBoxAddDelEditBakery.Text == Constants.edit)
                    {
                        if (comboBoxNameBakery.Text == string.Empty || comboBoxAddressBakery.Text == string.Empty || comboBoxPhoneBakery.Text == string.Empty)
                        {
                            MessageBox.Show("Введите данные во все поля", "Сообщение");
                        }
                        else
                        {
                           
                            if (!long.TryParse(comboBoxPhoneBakery.Text, out numberPhone))
                            {
                                MessageBox.Show("Неправильно задан номер телефона", "Сообщение");
                            }
                            else
                            {
                                if (comboBoxPhoneBakery.Text.Length != 11)
                                {
                                    MessageBox.Show("Неправильно задан номер телефона. Количество цифр не совпадает", "Сообщение");
                                }
                                else
                                {
                                    if(textBoxNameBakery.Text == string.Empty)
                                    {
                                        textBoxNameBakery.Text = comboBoxNameBakery.Text;
                                    }
                                    if(textBoxAddressBakery.Text == string.Empty)
                                    {
                                        textBoxAddressBakery.Text = comboBoxAddressBakery.Text;
                                    }
                                    if(textBoxPhoneBakery.Text == string.Empty)
                                    {
                                        textBoxPhoneBakery.Text = comboBoxPhoneBakery.Text;
                                    }
                                    DAL.UpBakery(DAL.GetBakeryNameId(comboBoxNameBakery.Text),textBoxNameBakery.Text, textBoxAddressBakery.Text, textBoxPhoneBakery.Text);
                                }
                            }
                        }
                    }
                    else if (comboBoxAddDelEditBakery.Text == Constants.delite)
                    {
                        DAL.DelBakery(DAL.GetBakeryNameId(comboBoxNameBakery.Text));
                    }
                }
            }
            else if (comboBoxAddDelEditBakery.Text == Constants.add)
            {
                if (comboBoxNameBakery.Text == string.Empty || comboBoxAddressBakery.Text == string.Empty || comboBoxPhoneBakery.Text == string.Empty)
                {
                    MessageBox.Show("Введите данные во все поля", "Сообщение");
                }
                else
                {
                    if (DAL.GetBakeryNameId(comboBoxNameBakery.Text) != 0)
                    {
                        MessageBox.Show("Завод c таким названием уже существует", "Сообщение");
                    }
                    else
                    {
                        if (!long.TryParse(comboBoxPhoneBakery.Text, out numberPhone))
                        {
                            MessageBox.Show("Неправильно задан номер телефона", "Сообщение");
                        }
                        else
                        {
                            if (comboBoxPhoneBakery.Text.Length != 11)
                            {
                                MessageBox.Show("Неправильно задан номер телефона. Количество цифр не совпадает", "Сообщение");
                            }
                            else
                            {
                                DAL.AddBakery(comboBoxNameBakery.Text, comboBoxAddressBakery.Text, comboBoxPhoneBakery.Text);
                            }
                        }
                    }
                }
            }
            comboBoxNameBakery.DataSource = DAL.GetBakeryName(comboBoxNameBakery.Text);
            comboBoxAddressBakery.DataSource = DAL.GetBakeryName(comboBoxAddressBakery.Text);
            comboBoxPhoneBakery.DataSource = DAL.GetBakeryName(comboBoxPhoneBakery.Text);
            dataGridViewBakery.DataSource = DAL.GetBreadFactory(textBoxBakerySearch.Text);
        }

        private void TextBoxKioskSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridViewKiosk.DataSource = DAL.GetKiosksOwner(textBoxKioskSearch.Text);
        }

        private void ComboBoxAddDelEditKiosk_TextChanged(object sender, EventArgs e)
        {
            if(comboBoxAddDelEditKiosk.Text == Constants.add)
            {
                comboBoxNameKiosk.Text = string.Empty;
                comboBoxNameKiosk.Enabled = true;
                comboBoxNameKiosk.DropDownStyle = ComboBoxStyle.Simple;

                textBoxNameKiosk.Text = string.Empty;
                textBoxNameKiosk.Enabled = false;

                comboBoxAddressKiosk.Text = string.Empty;
                comboBoxAddressKiosk.Enabled = true;
                comboBoxAddressKiosk.DropDownStyle = ComboBoxStyle.Simple;

                textBoxAddressKiosk.Text = string.Empty;
                textBoxAddressKiosk.Enabled = false;

                comboBoxPhoneKiosk.Text = string.Empty;
                comboBoxPhoneKiosk.Enabled = true;
                comboBoxPhoneKiosk.DropDownStyle = ComboBoxStyle.Simple;

                textBoxPhoneKiosk.Text = string.Empty;
                textBoxPhoneKiosk.Enabled = false;

                comboBoxBakeryKiosk.Text = string.Empty;
                comboBoxBakeryKiosk.Enabled = true;

                comboBoxBakeryKioskEddit.Text = string.Empty;
                comboBoxBakeryKioskEddit.Enabled = false;

                comboBoxOwnerKiosk.Text = string.Empty;
                comboBoxOwnerKiosk.Enabled = true;

                comboBoxOwnerKioskEddit.Text = string.Empty;
                comboBoxOwnerKioskEddit.Enabled = false;

                buttonKiosk.Enabled = true;
                buttonKiosk.Text = Constants.add;
                comboBoxBakeryKiosk.DataSource = DAL.GetBakeryName(string.Empty);
                comboBoxOwnerKiosk.DataSource = DAL.GetKioskOwner();
            }
            else if (comboBoxAddDelEditKiosk.Text == Constants.delite)
            {
                comboBoxNameKiosk.Text = string.Empty;
                comboBoxNameKiosk.Enabled = true;
                comboBoxNameKiosk.DropDownStyle = ComboBoxStyle.DropDown;

                textBoxNameKiosk.Text = string.Empty;
                textBoxNameKiosk.Enabled = false;

                comboBoxAddressKiosk.Text = string.Empty;
                comboBoxAddressKiosk.Enabled = true;
                comboBoxAddressKiosk.DropDownStyle = ComboBoxStyle.DropDown;

                textBoxAddressKiosk.Text = string.Empty;
                textBoxAddressKiosk.Enabled = false;

                comboBoxPhoneKiosk.Text = string.Empty;
                comboBoxPhoneKiosk.Enabled = true;
                comboBoxPhoneKiosk.DropDownStyle = ComboBoxStyle.DropDown;

                textBoxPhoneKiosk.Text = string.Empty;
                textBoxPhoneKiosk.Enabled = false;

                comboBoxBakeryKiosk.Text = string.Empty;
                comboBoxBakeryKiosk.Enabled = true;

                comboBoxBakeryKioskEddit.Text = string.Empty;
                comboBoxBakeryKioskEddit.Enabled = false;

                comboBoxOwnerKiosk.Text = string.Empty;
                comboBoxOwnerKiosk.Enabled = true;

                comboBoxOwnerKioskEddit.Text = string.Empty;
                comboBoxOwnerKioskEddit.Enabled = false;

                buttonKiosk.Enabled = true;

                buttonKiosk.Text = Constants.delite;
                comboBoxBakeryKiosk.DataSource = DAL.GetBakeryName(string.Empty);
                comboBoxOwnerKiosk.DataSource = DAL.GetKioskOwner();
            }
            else if(comboBoxAddDelEditKiosk.Text == Constants.edit)
            {
                comboBoxNameKiosk.Text = string.Empty;
                comboBoxNameKiosk.Enabled = true;
                comboBoxNameKiosk.DropDownStyle = ComboBoxStyle.DropDown;

                textBoxNameKiosk.Text = string.Empty;
                textBoxNameKiosk.Enabled = true;

                comboBoxAddressKiosk.Text = string.Empty;
                comboBoxAddressKiosk.Enabled = true;
                comboBoxAddressKiosk.DropDownStyle = ComboBoxStyle.DropDown;

                textBoxAddressKiosk.Text = string.Empty;
                textBoxAddressKiosk.Enabled = true;

                comboBoxPhoneKiosk.Text = string.Empty;
                comboBoxPhoneKiosk.Enabled = true;
                comboBoxPhoneKiosk.DropDownStyle = ComboBoxStyle.DropDown;

                textBoxPhoneKiosk.Text = string.Empty;
                textBoxPhoneKiosk.Enabled = true;

                comboBoxBakeryKiosk.Text = string.Empty;
                comboBoxBakeryKiosk.Enabled = true;

                comboBoxBakeryKioskEddit.Text = string.Empty;
                comboBoxBakeryKioskEddit.Enabled = true;

                comboBoxOwnerKiosk.Text = string.Empty;
                comboBoxOwnerKiosk.Enabled = true;

                comboBoxOwnerKioskEddit.Text = string.Empty;
                comboBoxOwnerKioskEddit.Enabled = true;

                buttonKiosk.Enabled = true;
                buttonKiosk.Text = Constants.edit;
                comboBoxBakeryKiosk.DataSource = DAL.GetBakeryName(string.Empty);
                comboBoxBakeryKioskEddit.DataSource = DAL.GetBakeryName(string.Empty);
                comboBoxOwnerKiosk.DataSource = DAL.GetKioskOwner();
                comboBoxOwnerKioskEddit.DataSource = DAL.GetKioskOwner();
            }
            comboBoxNameKiosk.DataSource = DAL.GetKiosksName(string.Empty);
            comboBoxAddressKiosk.DataSource = DAL.GetKioskAddress();
            comboBoxPhoneKiosk.DataSource = DAL.GetKioskPhone();
        }

        private void ButtonKiosk_Click(object sender, EventArgs e)
        {
            long numberPhone;
            if (comboBoxAddressKiosk.Text.Trim() == string.Empty || comboBoxNameKiosk.Text.Trim() == string.Empty || comboBoxPhoneKiosk.Text.Trim() == string.Empty ||
                comboBoxBakeryKiosk.Text.Trim() == string.Empty || comboBoxOwnerKiosk.Text.Trim() == string.Empty )
            {
                MessageBox.Show("Введите данные для всех полей", "Сообщение");
            }
            else
            {
                if (!long.TryParse(comboBoxPhoneKiosk.Text, out numberPhone))
                {
                    MessageBox.Show("Неправильно задан номер телефона", "Сообщение");
                }
                else
                {
                    if (comboBoxPhoneKiosk.Text.Length != 11)
                    {
                        MessageBox.Show("Неправильно задан номер телефона. Количество цифр не совпадает", "Сообщение");
                    }
                    else
                    {
                        if (comboBoxAddDelEditKiosk.Text == Constants.delite || comboBoxAddDelEditKiosk.Text == Constants.edit)
                        {
                            if (DAL.GetKioskNameId(comboBoxNameKiosk.Text) == 0)
                            {
                                MessageBox.Show("Данный киоск не найден", "Сообщение");
                            }
                            else
                            {
                                if(comboBoxAddDelEditKiosk.Text == Constants.delite)
                                {
                                    DAL.DelKiosk(DAL.GetKioskNameId(comboBoxNameKiosk.Text));
                                }
                                else if(comboBoxAddDelEditKiosk.Text == Constants.edit)
                                {
                                    if(textBoxNameKiosk.Text.Trim() == string.Empty)
                                    {
                                        textBoxNameKiosk.Text = comboBoxNameKiosk.Text;
                                    }
                                    if (textBoxAddressKiosk.Text.Trim() == string.Empty)
                                    {
                                        textBoxAddressKiosk.Text = comboBoxAddressKiosk.Text;
                                    }
                                    if (textBoxPhoneKiosk.Text.Trim() == string.Empty)
                                    {
                                        textBoxPhoneKiosk.Text = comboBoxPhoneKiosk.Text;
                                    }
                                    if (comboBoxBakeryKioskEddit.Text.Trim() == string.Empty)
                                    {
                                        comboBoxBakeryKioskEddit.Text = comboBoxBakeryKiosk.Text;
                                    }
                                    if (comboBoxOwnerKioskEddit.Text.Trim() == string.Empty)
                                    {
                                        comboBoxOwnerKioskEddit.Text = comboBoxOwnerKiosk.Text;
                                    }
                                    DAL.UpKiosk(DAL.GetKioskNameId(comboBoxNameKiosk.Text), textBoxNameKiosk.Text, textBoxAddressKiosk.Text, textBoxPhoneKiosk.Text,
                                        DAL.GetBakeryNameId(comboBoxBakeryKioskEddit.Text), DAL.GetOwnerId(comboBoxOwnerKioskEddit.Text));
                                }
                            }
                        }
                        else
                        {
                            if (DAL.GetKioskNameId(comboBoxNameKiosk.Text) != 0)
                            {
                                MessageBox.Show("Данное название киоска уже есть в таблице", "Сообщение");
                            }
                            else
                            {
                                DAL.AddKiosk(comboBoxNameKiosk.Text, comboBoxAddressKiosk.Text, comboBoxPhoneKiosk.Text,
                                    DAL.GetBakeryNameId(comboBoxBakeryKiosk.Text), DAL.GetOwnerId(comboBoxOwnerKiosk.Text));
                            }
                        }
                    }
                }
            }
            dataGridViewKiosk.DataSource = DAL.GetKiosksOwner(textBoxKioskSearch.Text);
        }

        private void ButtonLog_Click(object sender, EventArgs e)
        {
            dataGridViewLog.DataSource = DAL.GetLogSearch(dateTimePickerLogC.Value, dateTimePickerLogDo.Value);
        }
    }
}

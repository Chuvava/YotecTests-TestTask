using OpenQA.Selenium;
using YotecTestsV1.ComponentHelper;

namespace YotecTestsV1.PageObject.WeAreWabashPages
{
    public class SupportPage : BasePage
    {
        #region Data
        public string Url => "http://qa.yotec.net/we-are-wabash/support";
        public string Breadcrumb => ">Home>We Are Wabash>Support";
        public string ExpectedMessage => "Success! Thanks for filling out our form!";
        #endregion

        #region WebElement
        public By ChoiceComboBox => By.XPath("//span[@class='sfDropdownList sfFieldWrp']/select");
        public By CountryComboBox => By.XPath("//div[@class='sfFieldWrp']/select");
        public By NameTextBox => By.XPath("//input[@placeholder='Name']");
        public By EmailTextBox => By.XPath("//input[@placeholder='Email']");
        public By CompanyTextBox => By.XPath("//input[@placeholder='Company']");
        public By PhoneTextBox => By.XPath("//input[@placeholder='Phone']");
        public By CommentsTextArea => By.XPath("//textarea[@placeholder='Comments']");
        public By SubmitButton => By.XPath("//input[@value='Submit']");
        public By SuccessMessage => By.ClassName("sfSuccess");        
        #endregion

        #region Action
        public void FillOutForm(string choice, string country, 
            string name, string email, string company, string phone, string comments)
        {
            ComboBoxHelper.SelectElement(ChoiceComboBox, choice);
            ComboBoxHelper.SelectElement(CountryComboBox, country);
            TextBoxHelper.TypeInTextBox(NameTextBox, name);
            TextBoxHelper.TypeInTextBox(EmailTextBox, email);
            TextBoxHelper.TypeInTextBox(CompanyTextBox, company);
            TextBoxHelper.TypeInTextBox(PhoneTextBox, phone);
            TextBoxHelper.TypeInTextBox(CommentsTextArea, comments);
        }

        public void SubmitForm()
        {
            GenericHelper.ClickOnElement(SubmitButton);
        }

        public string GetSuccessMessage()
        {
            if (GenericHelper.IsElementPresent(SuccessMessage))
                return GenericHelper.GetElement(SuccessMessage).Text;
            return null;
        }
        #endregion
    }
}

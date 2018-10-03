using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using YotecTestsV1.BaseClasses;
using YotecTestsV1.ComponentHelper;
using YotecTestsV1.ExcelReader;
using YotecTestsV1.PageObject.WeAreWabashPages;


namespace YotecTestsV1.TestScript.HelpForm
{
    [TestClass]
    public class HelpFormTest : BaseTestClass
    {
        SupportPage supportPage;
        string excelPath = @"..\..\/TestData\testDataHelpForm.xlsx";
        string actualMessage;       

        [TestMethod, TestCategory("HelpForm")]
        public void HelpForm()
        {
            try
            {
                homePage.NavigateToSubMenu(homePage.WeAreWabashMenu, homePage.SupportSubMenu);

                supportPage = new SupportPage();
                supportPage.FillOutForm(ExcelReaderHelper.GetCellData(excelPath, 1, 0),
                    ExcelReaderHelper.GetCellData(excelPath, 1, 1),
                    ExcelReaderHelper.GetCellData(excelPath, 1, 2),
                    ExcelReaderHelper.GetCellData(excelPath, 1, 3),
                    ExcelReaderHelper.GetCellData(excelPath, 1, 4),
                    ExcelReaderHelper.GetCellData(excelPath, 1, 5),
                    ExcelReaderHelper.GetCellData(excelPath, 1, 6));
                supportPage.SubmitForm();

                if(supportPage.GetSuccessMessage() != null)
                {
                    actualMessage = supportPage.GetSuccessMessage();
                }
                else
                {
                    throw new Exception("Success message isn't present on the page");
                }
                Assert.AreEqual(supportPage.ExpectedMessage, actualMessage,
                    string.Format("Actual message: <{0}> is not equal to expected message: <{1}>", actualMessage, supportPage.ExpectedMessage));
                Logger.Info("ASSERT - Form completed successfuly");
            }
            catch (Exception exception)
            {
                GenericHelper.TakeScreenShot();
                Logger.Error(exception.Message);
                Logger.Error(exception.StackTrace);                
                throw;
            }                        
        }

    }
}

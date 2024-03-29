﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Automation.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Orders screen")]
    public partial class OrdersScreenFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "Everlight.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Orders screen", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add order on Orders screen")]
        [NUnit.Framework.TestCaseAttribute("4567", "Jacky", "John", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "06/08/2023 11:49 AM", null)]
        [NUnit.Framework.TestCaseAttribute("4568", "David", "Henry", "8743", "Care UK (CUK)", "Lincoln", "Xray (XR)", "07/09/2023 11:59 PM", null)]
        [NUnit.Framework.TestCaseAttribute("4569", "Daniel", "Kane", "8744", "The Ultrasound Clinic (USC)", "Clinic", "MRI (MR)", "27/11/2022 12:00 PM", null)]
        public virtual void AddOrderOnOrdersScreen(string mRN, string firstName, string lastName, string accessionNumber, string organisation, string siteId, string modality, string studyDateTime, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("MRN", mRN);
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("AccessionNumber", accessionNumber);
            argumentsOfScenario.Add("Organisation", organisation);
            argumentsOfScenario.Add("SiteId", siteId);
            argumentsOfScenario.Add("Modality", modality);
            argumentsOfScenario.Add("StudyDateTime", studyDateTime);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add order on Orders screen", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
 testRunner.Given("the user is on home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "MRN",
                            "FirstName",
                            "LastName",
                            "AccessionNumber",
                            "Organisation",
                            "SiteId",
                            "Modality",
                            "StudyDateTime"});
                table1.AddRow(new string[] {
                            string.Format("{0}", mRN),
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", accessionNumber),
                            string.Format("{0}", organisation),
                            string.Format("{0}", siteId),
                            string.Format("{0}", modality),
                            string.Format("{0}", studyDateTime)});
#line 5
 testRunner.When("the user adds a new order with following data", ((string)(null)), table1, "When ");
#line hidden
#line 8
 testRunner.Then(string.Format("the order should be added with accession number \'{0}\'", accessionNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
 testRunner.And(string.Format("delete the order with accession number \'{0}\'", accessionNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Order with duplicate accession number cannot be added on Orders screen")]
        [NUnit.Framework.TestCaseAttribute("5555", "6324", "6325", "An order already exists with accession number", null)]
        public virtual void OrderWithDuplicateAccessionNumberCannotBeAddedOnOrdersScreen(string accessionNumber, string mRN1, string mRN2, string error, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("AccessionNumber", accessionNumber);
            argumentsOfScenario.Add("MRN1", mRN1);
            argumentsOfScenario.Add("MRN2", mRN2);
            argumentsOfScenario.Add("error", error);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Order with duplicate accession number cannot be added on Orders screen", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 18
 testRunner.Given("the user is on home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "MRN",
                            "FirstName",
                            "LastName",
                            "AccessionNumber",
                            "Organisation",
                            "SiteId",
                            "Modality",
                            "StudyDateTime"});
                table2.AddRow(new string[] {
                            string.Format("{0}", mRN1),
                            "Jacky",
                            "John",
                            string.Format("{0}", accessionNumber),
                            "Lumus (LUM)",
                            "Ingleburn",
                            "CT (CT)",
                            "11/10/2022 12:02 AM"});
#line 19
 testRunner.When("the user adds a new order with following data", ((string)(null)), table2, "When ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "MRN",
                            "FirstName",
                            "LastName",
                            "AccessionNumber",
                            "Organisation",
                            "SiteId",
                            "Modality",
                            "StudyDateTime"});
                table3.AddRow(new string[] {
                            string.Format("{0}", mRN2),
                            "David",
                            "Henry",
                            string.Format("{0}", accessionNumber),
                            "Care UK (CUK)",
                            "Lincoln",
                            "Xray (XR)",
                            "31/05/2022 11:59 AM"});
#line 22
 testRunner.When("the user adds a new order with following data", ((string)(null)), table3, "When ");
#line hidden
#line 25
 testRunner.Then(string.Format("the order should not be added with error \'{0}\'", error), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 26
 testRunner.And(string.Format("delete the order with accession number \'{0}\'", accessionNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Verify orders are listed according to study datetime on Orders screen")]
        [NUnit.Framework.TestCaseAttribute("8756", "06/08/2023 11:49 AM", "8757", "07/09/2023 11:59 PM", null)]
        [NUnit.Framework.TestCaseAttribute("8756", "14/06/2023 09:25 AM", "8757", "09/06/2023 08:25 AM", null)]
        [NUnit.Framework.TestCaseAttribute("8756", "13/12/2023 11:49 PM", "8757", "13/12/2023 11:49 AM", null)]
        public virtual void VerifyOrdersAreListedAccordingToStudyDatetimeOnOrdersScreen(string accessionNumber1, string studyDateTime1, string accessionNumber2, string studyDateTime2, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("AccessionNumber1", accessionNumber1);
            argumentsOfScenario.Add("StudyDateTime1", studyDateTime1);
            argumentsOfScenario.Add("AccessionNumber2", accessionNumber2);
            argumentsOfScenario.Add("StudyDateTime2", studyDateTime2);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Verify orders are listed according to study datetime on Orders screen", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 32
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 33
 testRunner.Given("the user is on home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "MRN",
                            "FirstName",
                            "LastName",
                            "AccessionNumber",
                            "Organisation",
                            "SiteId",
                            "Modality",
                            "StudyDateTime"});
                table4.AddRow(new string[] {
                            "5269",
                            "Jacky",
                            "John",
                            string.Format("{0}", accessionNumber1),
                            "Lumus (LUM)",
                            "Ingleburn",
                            "CT (CT)",
                            string.Format("{0}", studyDateTime1)});
#line 34
 testRunner.When("the user adds a new order with following data", ((string)(null)), table4, "When ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "MRN",
                            "FirstName",
                            "LastName",
                            "AccessionNumber",
                            "Organisation",
                            "SiteId",
                            "Modality",
                            "StudyDateTime"});
                table5.AddRow(new string[] {
                            "5269",
                            "David",
                            "Henry",
                            string.Format("{0}", accessionNumber2),
                            "Care UK (CUK)",
                            "Lincoln",
                            "Xray (XR)",
                            string.Format("{0}", studyDateTime2)});
#line 37
 testRunner.When("the user adds a new order with following data", ((string)(null)), table5, "When ");
#line hidden
#line 40
 testRunner.Then(string.Format("the order should be listed in ascending order of study datetime \'{0}\', \'{1}\'", studyDateTime1, studyDateTime2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 41
 testRunner.And(string.Format("delete the order with accession number \'{0}\'", accessionNumber1), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 42
 testRunner.And(string.Format("delete the order with accession number \'{0}\'", accessionNumber2), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Order not added when data is missing")]
        [NUnit.Framework.TestCaseAttribute("7777", "Test", "Auto", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "31/06/2021 10:30 AM", "Study DateTime is required.", null)]
        [NUnit.Framework.TestCaseAttribute("7777", "Test", "Auto", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "29/02/2023 02:15 AM", "Study DateTime is required.", null)]
        [NUnit.Framework.TestCaseAttribute("8888", "Test", "Auto", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "25/12/2024 06:10 PM", "StudyDateTime cannot be in the future", null)]
        [NUnit.Framework.TestCaseAttribute("", "Test", "Auto", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "06/08/2021 11:49 AM", "MRN is required.", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "", "Auto", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "06/08/2021 11:49 AM", "First Name is required.", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "Test", "", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "06/08/2021 11:49 AM", "Last Name is required.", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "Test", "Auto", "", "Lumus (LUM)", "Ingleburn", "CT (CT)", "06/08/2021 11:49 AM", "Accession Number is required.", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "Test", "Auto", "8742", "", "Ingleburn", "CT (CT)", "06/08/2021 11:49 AM", "Organisation is required.", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "Test", "Auto", "8742", "Lumus (LUM)", "", "CT (CT)", "06/08/2021 11:49 AM", "Site is required.", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "Test", "Auto", "8742", "Lumus (LUM)", "Ingleburn", "", "06/08/2021 11:49 AM", "Modality: The Modality field is required.", null)]
        [NUnit.Framework.TestCaseAttribute("1234", "Test", "Auto", "8742", "Lumus (LUM)", "Ingleburn", "CT (CT)", "", "Study DateTime is required.", null)]
        public virtual void OrderNotAddedWhenDataIsMissing(string mRN, string firstName, string lastName, string accessionNumber, string organisation, string siteId, string modality, string studyDateTime, string error, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("MRN", mRN);
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("AccessionNumber", accessionNumber);
            argumentsOfScenario.Add("Organisation", organisation);
            argumentsOfScenario.Add("SiteId", siteId);
            argumentsOfScenario.Add("Modality", modality);
            argumentsOfScenario.Add("StudyDateTime", studyDateTime);
            argumentsOfScenario.Add("error", error);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Order not added when data is missing", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 50
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 51
 testRunner.Given("the user is on home page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "MRN",
                            "FirstName",
                            "LastName",
                            "AccessionNumber",
                            "Organisation",
                            "SiteId",
                            "Modality",
                            "StudyDateTime"});
                table6.AddRow(new string[] {
                            string.Format("{0}", mRN),
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", accessionNumber),
                            string.Format("{0}", organisation),
                            string.Format("{0}", siteId),
                            string.Format("{0}", modality),
                            string.Format("{0}", studyDateTime)});
#line 52
 testRunner.When("the user tries to add a new order with following data", ((string)(null)), table6, "When ");
#line hidden
#line 55
 testRunner.Then(string.Format("the order should not be added with error \'{0}\'", error), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

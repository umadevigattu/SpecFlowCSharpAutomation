using NUnit.Framework;
using RestSharp;
using SpecFlowBDDAutomationFramework.ComponentHelper;
using SpecFlowBDDAutomationFramework.Models;
using SpecFlowBDDAutomationFramework.Models.Request;
using SpecFlowBDDAutomationFramework.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.StepDefinitions.ApiSteps
{
    [Binding]
    public class CreateUserSteps
    {
        private const string BASE_URL = "https://reqres.in/";
        private readonly CreateUserReq createUserReq;
        private RestResponse response;


        public CreateUserSteps(CreateUserReq createUserReq)
        {
            this.createUserReq = createUserReq;
        }

        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string name)
        {
            createUserReq.name = name;
        }

        [Given(@"I input role ""(.*)""")]
        public void GivenIInputRole(string role)
        {
            createUserReq.job = role;
        }

        [When(@"I send create user request")]
        public async System.Threading.Tasks.Task WhenISendCreateUserRequestAsync()
        {
            var api = new ApiPage();
            response = await api.CreateNewUser(BASE_URL, createUserReq);
        }

        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(createUserReq.name, content.name);
            Assert.AreEqual(createUserReq.job, content.job);
        }
    }
}

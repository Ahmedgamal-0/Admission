using AdmissionSystem.Entities;
using AdmissionSystem.Models;
using AdmissionSystem.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdmissionSystem.Controllers
{
    [Route("api/AddApplicant")]
    public class AdmissionController : Controller
    {
        //private AdmissionSystemDbContext _admissionSystemDbContext;
        private IAdmissionRepo _AdmissionRepo;
        public AdmissionController(IAdmissionRepo AdmissionRepo)
        {
            _AdmissionRepo = AdmissionRepo;
        }

        [HttpPost]
        public IActionResult AddApplicant([FromBody] ApplicantForCreation ApplicantForCreation)
        {
            var final = Mapper.Map<Applicant>(ApplicantForCreation);
            _AdmissionRepo.AddApplicant(final);
            _AdmissionRepo.Save();

            return Ok();
        } 
        [HttpPost("{ApplicantId}/ParentInfo")]
        public IActionResult AddParentInfo(int ApplicantId,[FromBody] ParentInfoForCreation ParentInfoForCreation)
        {
            //Hi
            if (ParentInfoForCreation == null)
            {
                return BadRequest();
            }
            if (_AdmissionRepo.GetApplicant(ApplicantId) == null)
            {
                return NotFound();
            }
            var ParentInfo = Mapper.Map<ParentInfo>(ParentInfoForCreation);
            _AdmissionRepo.AddParentInfo(ApplicantId, ParentInfo);
            _AdmissionRepo.Save();
            return Ok();

        }
       

        [HttpPost("{ApplicantId}/EmergencyContact")]
        public IActionResult AddEmergencyContact(int ApplicantId, [FromBody] EmergencyContactForCreation EmergencyContactForCreation)
        {
            if (EmergencyContactForCreation == null)
            {
                return BadRequest();
            }
            if (_AdmissionRepo.GetApplicant(ApplicantId) == null)
            {
                return NotFound();
            }
            var EmergencyContact = Mapper.Map<EmergencyContact>(EmergencyContactForCreation);
            _AdmissionRepo.AddEmergencyContact(ApplicantId, EmergencyContact);
            _AdmissionRepo.Save();
            return Ok();
        }


      


        [HttpPost("AddSibling")]
        public IActionResult AddSibling(SiblingForCreation sibling)
        {
            if (sibling == null)
            {
                return BadRequest();
            }

            //HttpContext.Session.SetString("ApplicantId", "10");

            var siblingEntity = Mapper.Map<Sibling>(sibling);
            _AdmissionRepo.AddSibling(siblingEntity);

            if (!_AdmissionRepo.Save())
            {
                throw new Exception("failed to add an sibling");
            }

            return Ok();
            /*var siblingToReturn = Mapper.Map<SiblingDto>(siblingEntity);
            return CreatedAtRoute("getSibling", new { id = siblingToReturn.id }, siblingToReturn);
            */
        }

        [HttpPost("AddMedical")]
        public IActionResult AddMedicalDetails(MedicalHistoryForCreation medicalHistory)
        {
            if (medicalHistory == null)
            {
                return BadRequest();
            }

            var MedicalEntity = Mapper.Map<MedicalHistory>(medicalHistory);
            _AdmissionRepo.AddMedicalDetails(MedicalEntity);

            if (!_AdmissionRepo.Save())
            {
                throw new Exception("failed to add an sibling");
            }

            return Ok();
            /*var MedicalHistoryToReturn = Mapper.Map<MedicalHistoryDto>(MedicalEntity);
            return CreatedAtRoute("getMedicalHistory", new { id = MedicalHistoryToReturn.id }, MedicalHistoryToReturn);
            */

        }


        [HttpPost("MakePayment")]
        public async Task<IActionResult> MakePaymentAsync()
        {

            var Auth = JsonConvert.SerializeObject(
                new
                {
                    api_key = "ZXlKMGVYQWlPaUpLVjFRaUxDSmhiR2NpT2lKSVV6VXhNaUo5LmV5SmpiR0Z6Y3lJNklrMWxjbU5vWVc1MElpd2ljSEp2Wm1sc1pWOXdheUk2TVRBek9URTRMQ0p1WVcxbElqb2lhVzVwZEdsaGJDSjkubDZkaGtQMmtaOTFiN1lKQ2Jyd0d6bnNnN0xBTk1tOU9kdUs0LUhXN010OURmeWJRckxORzJhbllxM1pOX2xHQy1RWmZjVDNQeUpTUzBHNTdMbnk2S3c="
                }
                );
            var reqContent1 = new StringContent(Auth, Encoding.UTF8, "application/json");
            var url = "https://accept.paymob.com/api/auth/tokens";

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(url, reqContent1);
            

            string AuthResult = response.Content.ReadAsStringAsync().Result;

            //Console.WriteLine(AuthResult);
            
            dynamic marchentData = JObject.Parse(AuthResult);
            //Console.WriteLine(marchentData.token);

            //==========================
            var OrderRegistration = JsonConvert.SerializeObject(
                new
                {
                    auth_token = marchentData.token,
                    delivery_needed = "false",
                    merchant_id = marchentData.profile.user.id,      // merchant_id obtained from step 1
                    amount_cents = "100",               // The price of the order in cents.
                    currency = "EGP"
                }
                );
            var reqContent2 = new StringContent(OrderRegistration, Encoding.UTF8, "application/json");
            url = "https://accept.paymob.com/api/ecommerce/orders";

            client = new HttpClient();
            response = await client.PostAsync(url, reqContent2);

            string OrderResult = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(OrderResult);

            
            dynamic orderData = JObject.Parse(OrderResult);
            //Console.WriteLine(orderData.token);

            //====================================================
            // if(method == visa ){
            var GetKey = JsonConvert.SerializeObject(
                new
                {
                    auth_token = marchentData.token, // auth token obtained from step1
                    delivery_needed = "false",
                    order_id = orderData.id,
                    expiration = 3600000000,
                    integration_id = 267725,      // card integration_id will be provided upon signing up,
                    billing_data = new
                    {
                        apartment = "2",
                        email = "Mahmoud@gmail.com",
                        floor = "8",
                        first_name = "Mahmoud",
                        street = "haram",
                        building = "8028",
                        phone_number = "+86(8)9135210487",
                        shipping_method = "PKG",
                        postal_code = "01898",
                        city = "Jaskolskiburgh",
                        country = "CR",
                        last_name = "Ali",
                        state = "Utah"
                    },
                    merchant_id = marchentData.profile.user.id,      // merchant_id obtained from step 1
                    amount_cents = 20000,     //The price should be paid through this payment channel with this payment key token.
                    currency = "EGP"

                }
                );
            var reqContent3 = new StringContent(GetKey, Encoding.UTF8, "application/json");
            url = "https://accept.paymob.com/api/acceptance/payment_keys";

            client = new HttpClient();
            response = await client.PostAsync(url, reqContent3);

            string lastOrderResult = response.Content.ReadAsStringAsync().Result;
            //Console.WriteLine(lastOrderResult);

            dynamic lastOrderData = JObject.Parse(lastOrderResult);
            //Console.WriteLine(lastOrderData.token);
            //Console.WriteLine("--------------- url ------------");

            //Console.WriteLine("https://accept.paymob.com/api/acceptance/iframes/241121?payment_token=" + lastOrderData.token);
            Redirect("https://accept.paymob.com/api/acceptance/iframes/241121?payment_token=" + lastOrderData.token);


            /*if (method = aman)
            {
                var GetKioskKey = JsonConvert.SerializeObject(
                new
                {
                    auth_token = marchentData.token, // auth token obtained from step1
                    delivery_needed = "false",
                    order_id = orderData.id,
                    expiration = 3600000000,
                    integration_id = 270214,    // card integration_id will be provided upon signing up,
                    billing_data = new
                    {
                        apartment = "2",
                        email = "Mahmoud@gmail.com",
                        floor = "8",
                        first_name = "Mahmoud",
                        street = "haram",
                        building = "8028",
                        phone_number = "+86(8)9135210487",
                        shipping_method = "PKG",
                        postal_code = "01898",
                        city = "Jaskolskiburgh",
                        country = "CR",
                        last_name = "Ali",
                        state = "Utah"
                    },
                    merchant_id = marchentData.profile.user.id,      // merchant_id obtained from step 1
                    amount_cents = 20000,        //The price should be paid through this payment channel with this payment key token.
                    currency = "EGP"

                }
                );
                var reqResult4 = new StringContent(GetKey, Encoding.UTF8, "application/json");
                url = "https://accept.paymob.com/api/acceptance/payment_keys";

                client = new HttpClient();
                response = await client.PostAsync(url, reqResult4);

                string lastOrderResult = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(lastOrderResult);

                dynamic results3 = JObject.Parse(lastOrderResult);

                var GetBillReference = JsonConvert.SerializeObject(
                new
                {
                    source = new
                    {
                        identifier = "AGGREGATOR",
                        subtype = "AGGREGATOR"
                    },
                    payment_token = results3.token
                }
                );
                var reqContent = new StringContent(GetKey, Encoding.UTF8, "application/json");
                url = "https://accept.paymob.com/api/acceptance/payments/pay";

                client = new HttpClient();
                response = await client.PostAsync(url, lastOrderData);

                string lastOrderResult = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(lastOrderResult);
                
                dynamic results3 = JObject.Parse(lastOrderResult);
            }
            */



            return Ok();
        }








    }
}
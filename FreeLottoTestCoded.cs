﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FreeLottoTest
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Microsoft.VisualStudio.TestTools.WebTesting.Rules;


    [DataSource("FreelottoCredentials", "System.Data.SqlClient", "Data Source=MATT-SERVER;Initial Catalog=MySecureParameters;Integrated Security=Tr" +
        "ue", Microsoft.VisualStudio.TestTools.WebTesting.DataBindingAccessMethod.Sequential, Microsoft.VisualStudio.TestTools.WebTesting.DataBindingSelectColumns.SelectOnlyBoundColumns, "vwFreelottoCredentials")]
    [DataBinding("FreelottoCredentials", "vwFreelottoCredentials", "FreeLottoUsername", "FreelottoCredentials.vwFreelottoCredentials.FreeLottoUsername")]
    [DataBinding("FreelottoCredentials", "vwFreelottoCredentials", "FreeLottoPassword", "FreelottoCredentials.vwFreelottoCredentials.FreeLottoPassword")]
    public class FreeLottoTestCoded : WebTest
    {

        public FreeLottoTestCoded()
        {
            this.Context.Add("WebServer1", "https://www.freelotto.com");
            this.Context.Add("WebServer2", "http://i.pinid.com");
            this.Context.Add("WebServer3", "http://fl9875309.b.circonus.com:0");
            this.Context.Add("WebServer4", "http://www.freelotto.com");
            this.Context.Add("WebServer5", "https://www.upsellit.com");
            this.Context.Add("WebServer6", "http://www.upsellit.com");
            this.Context.Add("WebServer7", "https://urs.microsoft.com");
            this.PreAuthenticate = true;
        }

        public override IEnumerator<WebTestRequest> GetRequestEnumerator()
        {
            // Initialize validation rules that apply to all requests in the WebTest
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low))
            {
                ValidateResponseUrl validationRule1 = new ValidateResponseUrl();
                this.ValidateResponse += new EventHandler<ValidationEventArgs>(validationRule1.Validate);
            }
            if ((this.Context.ValidationLevel >= Microsoft.VisualStudio.TestTools.WebTesting.ValidationLevel.Low))
            {
                ValidationRuleResponseTimeGoal validationRule2 = new ValidationRuleResponseTimeGoal();
                validationRule2.Tolerance = 0D;
                this.ValidateResponseOnPageComplete += new EventHandler<ValidationEventArgs>(validationRule2.Validate);
            }

            CountingLoopRule conditionalRule1 = new CountingLoopRule();
            conditionalRule1.ContextParameterName = "Loop Counter";
            conditionalRule1.IterationsCount = 6D;

            int maxIterations1 = -1;
            bool advanceDataCursors1 = false;
            this.BeginLoop(conditionalRule1, maxIterations1, advanceDataCursors1);
            this.RegisterDataSourceInLoop(conditionalRule1, "FreelottoCredentials", "vwFreelottoCredentials");

            for (; this.ExecuteConditionalRule(conditionalRule1); )
            {
                WebTestRequest request1 = new WebTestRequest((this.Context["WebServer1"].ToString() + "/LottoPicker/login.asp"));
                request1.ThinkTime = 10;
                ExtractHiddenFields extractionRule1 = new ExtractHiddenFields();
                extractionRule1.Required = true;
                extractionRule1.HtmlDecode = true;
                extractionRule1.ContextParameterName = "1";
                request1.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule1.Extract);
                yield return request1;
                request1 = null;

                WebTestRequest request2 = new WebTestRequest((this.Context["WebServer1"].ToString() + "/LottoPicker/login.asp"));
                request2.Method = "POST";
                request2.ExpectedResponseUrl = "http://www.freelotto.com/LottoPicker/play.asp";
                FormPostHttpBody request2Body = new FormPostHttpBody();
                request2Body.FormPostParameters.Add("WhereTo", "/LottoPicker/play.asp");
                request2Body.FormPostParameters.Add("numbers", "");
                request2Body.FormPostParameters.Add("username", this.Context["FreelottoCredentials.vwFreelottoCredentials.FreeLottoUsername"].ToString());
                request2Body.FormPostParameters.Add("password", this.Context["FreelottoCredentials.vwFreelottoCredentials.FreeLottoPassword"].ToString());
                request2Body.FormPostParameters.Add("submitted", "Login");
                request2.Body = request2Body;
                WebTestRequest request2Dependent1 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SSBanner_LPtest/WINmh_control10_English_728" +
                        "x90.swf"));
                request2.DependentRequests.Add(request2Dependent1);
                WebTestRequest request2Dependent2 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SS_banners2/wh_scratcherNwin_english_160x60" +
                        "0.swf"));
                request2.DependentRequests.Add(request2Dependent2);
                WebTestRequest request2Dependent3 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SSBanner_LPtest/WINmh_control10_English_728" +
                        "x90.swf"));
                request2.DependentRequests.Add(request2Dependent3);
                WebTestRequest request2Dependent4 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SS_banners2/wh_scratcherNwin_english_160x60" +
                        "0.swf"));
                request2.DependentRequests.Add(request2Dependent4);
                ExtractHiddenFields extractionRule2 = new ExtractHiddenFields();
                extractionRule2.Required = true;
                extractionRule2.HtmlDecode = true;
                extractionRule2.ContextParameterName = "1";
                request2.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule2.Extract);
                yield return request2;
                request2 = null;

                WebTestRequest request3 = new WebTestRequest((this.Context["WebServer3"].ToString() + "/hit"));
                request3.ThinkTime = 10;
                request3.QueryStringParameters.Add("dom_time", "1316", false, false);
                request3.QueryStringParameters.Add("load_time", "2457", false, false);
                yield return request3;
                request3 = null;

                // $1,000,000.00 USD Daily Jackpot number limits are from 1 to 54 of 6 non-duplication numbers.
                this.AddCommentToResult("$1,000,000.00 USD Daily Jackpot number limits are from 1 to 54 of 6 non-duplicati" +
                        "on numbers.");

                // WIN A CAR number limits are from 1 to 42 of 6 non-duplicating numbers.
                this.AddCommentToResult("WIN A CAR number limits are from 1 to 42 of 6 non-duplicating numbers.");

                // Pay Off Your Mortgage number limits are from 1 to 47 of 6 non-duplicating numbers.
                this.AddCommentToResult("Pay Off Your Mortgage number limits are from 1 to 47 of 6 non-duplicating numbers" +
                        ".");

                // FastCASH $10,000.00 USD number limits are from 1 to 33 of 6 non-duplicating numbers.
                this.AddCommentToResult("FastCASH $10,000.00 USD number limits are from 1 to 33 of 6 non-duplicating numbe" +
                        "rs.");

                // $100,000.00 USD Giveaway number limits are from 1 to 47 of 6 non-duplicating numbers.
                this.AddCommentToResult("$100,000.00 USD Giveaway number limits are from 1 to 47 of 6 non-duplicating numb" +
                        "ers.");

                // $10,000,000.00 USD number limits are from 1 to 50 of 7 non-duplication numbers.
                this.AddCommentToResult("$10,000,000.00 USD number limits are from 1 to 50 of 7 non-duplication numbers.");

                WebTestRequest request4 = new WebTestRequest((this.Context["WebServer4"].ToString() + "/LottoPicker/playInsert.asp"));
                request4.Method = "POST";
                request4.ExpectedResponseUrl = "https://www.freelotto.com/register_7083.asp?skin=7083&playInsert=1&source=15677";
                request4.QueryStringParameters.Add("playgame", this.Context["$HIDDEN1.playgame"].ToString(), false, false);
                FormPostHttpBody request4Body = new FormPostHttpBody();
                request4Body.FormPostParameters.Add("clickedhotpicks", this.Context["$HIDDEN1.clickedhotpicks"].ToString());
                request4Body.FormPostParameters.Add("sweep_type", this.Context["$HIDDEN1.sweep_type"].ToString());
                request4Body.FormPostParameters.Add("sweep_id", this.Context["$HIDDEN1.sweep_id"].ToString());
                request4Body.FormPostParameters.Add("numbers", this.Context["$HIDDEN1.numbers"].ToString());
                request4Body.FormPostParameters.Add("source", this.Context["$HIDDEN1.source"].ToString());
                request4Body.FormPostParameters.Add("gameno", this.Context["$HIDDEN1.gameno"].ToString());
                request4Body.FormPostParameters.Add("arg1", this.Context["$HIDDEN1.arg1"].ToString());
                request4Body.FormPostParameters.Add("playgame", this.Context["$HIDDEN1.playgame"].ToString());
                request4Body.FormPostParameters.Add("num1", "1");
                request4Body.FormPostParameters.Add("num4", "4");
                request4Body.FormPostParameters.Add("num19", "19");
                request4Body.FormPostParameters.Add("num24", "24");
                request4Body.FormPostParameters.Add("num33", "33");
                request4Body.FormPostParameters.Add("num42", "42");
                request4Body.FormPostParameters.Add("text", "1,4,19,24,33,42");
                request4Body.FormPostParameters.Add("intervalType42490", this.Context["$HIDDEN1.intervalType42490"].ToString());
                request4Body.FormPostParameters.Add("slot42490", this.Context["$HIDDEN1.slot42490"].ToString());
                request4Body.FormPostParameters.Add("banner_42490", "banner_42490");
                request4Body.FormPostParameters.Add("fast_yes.x", "24");
                request4Body.FormPostParameters.Add("fast_yes.y", "8");
                request4.Body = request4Body;
                WebTestRequest request4Dependent1 = new WebTestRequest((this.Context["WebServer7"].ToString() + "/urs.asmx"));
                request4Dependent1.Method = "POST";
                request4Dependent1.Headers.Add(new WebTestRequestHeader("SOAPAction", "\"http://Microsoft.STS.STSWeb/RepLookup\""));
                request4Dependent1.QueryStringParameters.Add("MSURS-Client-Key", "EhdqEbeDdIJdzlUnnLY5Yw%3d%3d", false, false);
                request4Dependent1.QueryStringParameters.Add("MSURS-Patented-Lock", "h%2bZ6LKPL7Bs%3d", false, false);
                StringHttpBody request4Dependent1Body = new StringHttpBody();
                request4Dependent1Body.ContentType = "text/xml; charset=utf-8";
                request4Dependent1Body.InsertByteOrderMark = false;
                request4Dependent1Body.BodyString = @"<soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soapenc=""http://schemas.xmlsoap.org/soap/encoding/""><soap:Body><RepLookup xmlns=""http://Microsoft.STS.STSWeb/""><G>{2CEDBFBC-DBA8-43AA-B1FD-CC8E6316E3E2}</G><O>{6C2BDA4A-56C4-4105-9634-3EEB51D49562}</O><P>{6828F1C8-FCF0-4950-B35F-FF2205DFF92A}</P><D>8.0.6001.9</D><C>8.00.6001.18669</C><S>6.1.7600.0.0</S><I>8.0.7600.16385</I><L>en-US</L><R xmlns:q1=""http://Microsoft.STS.STSWeb/"" soapenc:arrayType=""q1:Rq[1]""><Rq><T>URL</T><R>https://www.freelotto.com/register_7083.asp?skin=7083&amp;playInsert=1&amp;source=15677</R><O>PRE</O><W>FRAME</W></Rq></R></RepLookup></soap:Body></soap:Envelope>";
                request4Dependent1.Body = request4Dependent1Body;
                request4.DependentRequests.Add(request4Dependent1);
                WebTestRequest request4Dependent2 = new WebTestRequest((this.Context["WebServer5"].ToString() + "/upsellitJS4.jsp"));
                request4Dependent2.QueryStringParameters.Add("qs", "217255226254331307309277297334279324311335324340290327295328", false, false);
                request4Dependent2.QueryStringParameters.Add("siteID", "3472", false, false);
                request4Dependent2.QueryStringParameters.Add("trackingInfo", "/register_7083.asp%3Fskin%3D7083%26tempid%3D%26lang%3Den%26noepu%3D1%26partner%3D" +
                        "15677%26affiliateid%3D%26upchat%3Dtrue", false, false);
                request4.DependentRequests.Add(request4Dependent2);
                WebTestRequest request4Dependent3 = new WebTestRequest((this.Context["WebServer5"].ToString() + "/chat_slim.swf"));
                request4.DependentRequests.Add(request4Dependent3);
                yield return request4;
                request4 = null;

                WebTestRequest request5 = new WebTestRequest((this.Context["WebServer1"].ToString() + "/xmljs/countrystate.asp"));
                request5.ThinkTime = 10;
                request5.QueryStringParameters.Add("cid", "United%20States", false, false);
                request5.QueryStringParameters.Add("rid", "0.9216831541026262", false, false);
                yield return request5;
                request5 = null;

                WebTestRequest request6 = new WebTestRequest((this.Context["WebServer6"].ToString() + "/httpPost.jsp"));
                request6.ThinkTime = 10;
                request6.QueryStringParameters.Add("command", "OPENER", false, false);
                request6.QueryStringParameters.Add("chatID", "1347701059591396835402", false, false);
                request6.QueryStringParameters.Add("msg", @"%3Cb%3EAshley%20Says%3A%3C/b%3E%20Hey%20wait%21%20We%20hate%20to%20see%20you%20go.%20Millionaires%20are%20made%20here%20at%20FreeLotto%20and%20you%20could%20be%20our%20next%20big%20winner%21%20Sign%20up%20to%20the%20F.A.S.T.%20%28FreeLotto%20Automatic%20Subscription%20Ticket%29%20service%20now%20for%20automated%20daily%20game%20entry%20and%20receive%20a%20%245%20OFF%20your%20first%20Month%21%3Cbr%3E%3Cbr%3E%20%3Ca%20href%3D%27asfunction%3A_root.openAndRecord%2CLINK1%2C1%27%3E%3Cfont%20color%3D%27%231E00FF%27%3E%3Cb%3ECLICK%20HERE%3C/b%3E%3C/font%3E%3C/a%3E%20to%20claim%20this%20special%20one-time%20Chat%20Bonus%20and%20start%20playing%20for%20your%20chance%20at%20winning%20over%20%2411%2C000%2C000%20in%20daily%20cash%20and%20prizes%21", false, false);
                request6.QueryStringParameters.Add("version", "WIN+10,1,102,64", false, false);
                request6.QueryStringParameters.Add("sess", "AAC6CAD63E6D803BC879C0B9E70000B1", false, false);
                request6.QueryStringParameters.Add("r1", "5004", false, false);
                request6.QueryStringParameters.Add("r2", "5753", false, false);
                request6.QueryStringParameters.Add("cID", "1347701059591396835402", false, false);
                yield return request6;
                request6 = null;

                WebTestRequest request7 = new WebTestRequest((this.Context["WebServer4"].ToString() + "/LottoPicker/play.asp"));
                WebTestRequest request7Dependent1 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SSBanner_LPtest/WINmh_control10_English_728" +
                        "x90.swf"));
                request7.DependentRequests.Add(request7Dependent1);
                WebTestRequest request7Dependent2 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SSBanner_LPtest/WINmh_control10_English_728" +
                        "x90.swf"));
                request7.DependentRequests.Add(request7Dependent2);
                WebTestRequest request7Dependent3 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SS_banners2/wh_scratcherNwin_english_160x60" +
                        "0.swf"));
                request7.DependentRequests.Add(request7Dependent3);
                WebTestRequest request7Dependent4 = new WebTestRequest((this.Context["WebServer2"].ToString() + "/www.freelotto.com//dynamic/akamaizer/SS_banners2/wh_scratcherNwin_english_160x60" +
                        "0.swf"));
                request7.DependentRequests.Add(request7Dependent4);
                ExtractHiddenFields extractionRule3 = new ExtractHiddenFields();
                extractionRule3.Required = true;
                extractionRule3.HtmlDecode = true;
                extractionRule3.ContextParameterName = "1";
                request7.ExtractValues += new EventHandler<ExtractionEventArgs>(extractionRule3.Extract);
                yield return request7;
                request7 = null;

                WebTestRequest request8 = new WebTestRequest((this.Context["WebServer3"].ToString() + "/hit"));
                request8.ThinkTime = 10;
                request8.QueryStringParameters.Add("dom_time", "244", false, false);
                request8.QueryStringParameters.Add("load_time", "450", false, false);
                yield return request8;
                request8 = null;
            }

            this.EndLoop(conditionalRule1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using BellagioService.Library;
using Newtonsoft.Json;
using Microsoft.AspNet.Mvc;
using BellagioService.Service.v1.Models;
using HiMVC.Controllers;

namespace BellagioService.Service.v1.Controllers
{

    //[HandleJsonError]
    //[RequireHttps, ServiceAuthorize, ActivityLog]
    public class ServiceController : BaseController
    {
        public ServiceController() : base(null, null)
        {

        }

        #region Services
        //
        // GET: /Service/
        
       
        /// <summary>
        /// Play Lottery
        /// </summary>
        /// <param name="entry"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Play(EntryModelX entry)
        {
            string responseCode = Constants.SVC_STATUS_ERROR;
            string transactionNumber = Util.GetTransactionNumber();

            //if (!entry.Equals(new EntryModelX())) // not declared
            //{
                //LogServiceInfo("Play", entry.ToString());

            //    var draw = _repository.GetTodayDraw(entry.DrawId);

            //    if (draw != null)
            //    {
            //        if (false /*!draw.IsClosed*/)
            //        {
            //            if (ValidateEntry(entry))
            //            {
            //                var agent = _repository.GetVendor(entry.OperatorId);

            //                if (agent != null /*&& agent.Password == SecurityUtil.SHA1HashString(entry.PIN)*/)
            //                {
            //                    if (true /*agent.IsActive*/)
            //                    {

            //                        if (!_repository.SequenceExist(entry.SequenceNumber))
            //                        {
            //                            decimal balance = 0M;// _repository.Balance(agent.Username);

            //                            //if (balance <= 500)
            //                            //    Util.SendEmail(new string[] { agent.Email }, "Low Account Balance", "Your Eliest account balance is low - =N=" + balance);

            //                            if (balance > entry.AmountPayed)
            //                            {
            //                                SubmitEntry(transactionNumber, entry);
            //                                responseCode = Constants.SVC_STATUS_OK;
            //                            }
            //                            else
            //                                responseCode = Constants.SVC_INSUFFICIENT_CREDIT;
            //                        }
            //                        else
            //                            responseCode = Constants.SVC_SEQUENCE_DUPLICATED;
            //                    }
            //                    else
            //                        responseCode = Constants.SVC_VENDOR_SUSPENDED;
            //                }
            //                else
            //                    responseCode = Constants.SVC_INVALID_CREDENTIAL;
            //            }
            //            else
            //                responseCode = Constants.SVC_INVALID_ENTRY;
            //        }
            //        else
            //            responseCode = Constants.SVC_DRAW_CLOSED;
            //    }
            //    else
            //        responseCode = Constants.SVC_INVALID_DRAW;
                    
            //}
            //else
            //    responseCode = Constants.SVC_MISSING_PAYLOAD;

            var response = new ResponseModel() { TransactionId = transactionNumber, ResponseCode = responseCode };
            LogServiceInfo("Play", JsonConvert.SerializeObject(response));
            return Json(response);
        }

        /// <summary>
        /// Get Winning Lucky number for a draw
        /// </summary>
        /// <param name="drawId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WinNumber(string drawId)
        {
            string message = null;
            string responseCode = Constants.SVC_STATUS_ERROR;

            LogServiceInfo("WinNumber", drawId);

            //var draw = _repository.GetTodayDraw(drawId);

            //if (draw != null)
            //{
            //    responseCode = Constants.SVC_STATUS_OK;

            //    if (false/*string.IsNullOrEmpty(draw.WinningNumber)*/)
            //        message = "Winning number not drawn yet!";
            //    else
            //        message = string.Format("{0} : {1}", 5, "0:4:3"/*draw.WinningNumber, draw.MachineGeneratedCode*/);
            //}
            //else
            //    responseCode = Constants.SVC_OBJECT_NOT_EXIST;

            var response = new ResponseModel { TransactionId = "00000000", ResponseCode = responseCode, PayLoad = message };

            LogServiceInfo("WinNumber", JsonConvert.SerializeObject(response));
            return Json(response);
        }

        /// <summary>
        /// Get vendor account balance
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Balance(string operatorId)
        {
            LogServiceInfo("Balance", operatorId);

            string message = null;
            string responseCode = Constants.SVC_STATUS_ERROR;

            //var op = _repository.GetVendor(operatorId);

            //if (op != null)
            //{
                //message = _repository.Balance(operatorId).ToString();//op.Balance.ToString();
                responseCode = Constants.SVC_STATUS_OK;
            //}
            //else
            //    responseCode = Constants.SVC_OBJECT_NOT_EXIST;
                

            var response = new ResponseModel { TransactionId = "00000000", ResponseCode = responseCode, PayLoad = message };

            LogServiceInfo("Balance", JsonConvert.SerializeObject(response));
            return Json(response);
        }

        /// <summary>
        /// Get current draw
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public JsonResult Draw()
        {
            //LogServiceInfo("Draw", "Invoke");

            IEnumerable<DrawModel> _draws;

            if (false /*!CacheManager.Get<IEnumerable<DrawModel>>(Constants.DRAW_CACHE, out _draws)*/)
            {
                //var draws = _repository.GetActiveDraw();
                //_draws = null;// draws.Select(d => Mapping.GetDrawModel(d));

                //CacheManager.Add<IEnumerable<DrawModel>>(_draws, Constants.DRAW_CACHE, ComputerMin2Midnight());
            }

            var response =  new ResponseModel { TransactionId = "00000000", ResponseCode = Constants.SVC_STATUS_OK/*, PayLoad = _draws*/ };

            LogServiceInfo("Draw", JsonConvert.SerializeObject(response));
            var json = Json(response/*, JsonRequestBehavior.AllowGet*/);

            return json;
        }

        private double ComputerMin2Midnight()
        {
            return 0d; // CommonLibrary.ToNigerianLocalTime(DateTime.Now).Date.AddDays(1).Subtract(CommonLibrary.ToNigerianLocalTime(DateTime.Now)).TotalMinutes;
        }

        /// <summary>
        /// Get number of accepted entries
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Count(string operatorId)
        {
            LogServiceInfo("Count", operatorId);

            var count = 0;// _repository.GetEntryCount(operatorId, CommonLibrary.ToNigerianLocalTime(DateTime.Now).Date);
            var response = new ResponseModel { TransactionId = "00000000", ResponseCode = Constants.SVC_STATUS_OK, PayLoad = count.ToString() };

            LogServiceInfo("Count", JsonConvert.SerializeObject(response));
            return Json(response);
        }
        

        /// <summary>
        /// Reinburse vendor account
        /// </summary>
        /// <param name="drawId"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Refill(RefillModel refill)
        {
            LogServiceInfo("Refill", refill.ToString());

            decimal? balance = null;
            string responseCode = Constants.SVC_STATUS_ERROR;
            string transactionNumber = Util.GetTransactionNumber();

            if (!refill.Equals(new RefillModel())) // not declared
            {
                if (ValidateRefill(refill))
                {

                    //if (!_repository.SequenceExist(refill.SequenceNumber))
                    //{

                    //    balance = SubmitRefill(transactionNumber, refill);

                    //    if (balance.HasValue)
                    //        responseCode = Constants.SVC_STATUS_OK;
                    //    else
                    //        responseCode = Constants.SVC_OBJECT_NOT_EXIST;
                    //}
                    //else
                    //    responseCode = Constants.SVC_SEQUENCE_DUPLICATED;
                }
                else
                    responseCode = Constants.SVC_INVALID_REFILL;
            }
            else
                responseCode = Constants.SVC_MISSING_PAYLOAD;

            var response = new ResponseModel { TransactionId = transactionNumber, ResponseCode = responseCode, PayLoad = balance.ToString() };

            LogServiceInfo("Refill", JsonConvert.SerializeObject(response));
            return Json(response);
        }

        /// <summary>
        /// Vendor PIN change
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ChangePIN(PINModel pin)
        {
            string responseCode = Constants.SVC_STATUS_ERROR;
            LogServiceInfo("ChangePIN", pin.ToString());
                
            if (!pin.Equals(new PINModel())) // not declared
            {
                //if (_repository.ChangePIN(pin.OperatorId, pin.OldPIN, pin.NewPIN))
                //{
                //    responseCode = Constants.SVC_STATUS_OK;

                //    //CacheManager.Clear(string.Format("{0}.{1}", Constants.USER_CACHE_BASE, pin.OperatorId));
                //}
                //else
                //    responseCode = Constants.SVC_INVALID_CREDENTIAL;
            }
            else
                responseCode = Constants.SVC_MISSING_PAYLOAD;

            var response = new ResponseModel { TransactionId = Util.GetTransactionNumber(), ResponseCode = responseCode };

            LogServiceInfo("ChangePIN", JsonConvert.SerializeObject(response));
            return Json(response);
        }

        /// <summary>
        /// Reverse/void refill transactions and play entry
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Reverse(ReversalModel model)
        {
            string responseCode = Constants.SVC_STATUS_ERROR;
            LogServiceInfo("Reverse", model.ToString());

            if (!string.IsNullOrEmpty(model.SequenceNumber))
            {
                //if (_repository.ReverseTransaction(model.OperatorId, model.SequenceNumber))
                //    responseCode = Constants.SVC_STATUS_OK;
                //else
                //    responseCode = Constants.SVC_STATUS_ERROR;
            }
            else
                responseCode = Constants.SVC_MISSING_PAYLOAD;

            var response = new ResponseModel { TransactionId = Util.GetTransactionNumber(), ResponseCode = responseCode };

            LogServiceInfo("Reverse", JsonConvert.SerializeObject(response));
            return Json(response);
        }


        #endregion

        #region Service Helpers

        private bool IsValidLuckyNumber(string entryNumber, string gameType)
        {
            // check lucky number format
            return ValidateGameEntry(entryNumber, gameType);
        }

        private bool ValidateGameEntry(string entryNumber, string gameType)
        {

            var status = false;

            switch (gameType)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                    var entry = entryNumber.Split('-');

                    status = Util.ValidateLotteryNumber(entryNumber) && entry.Length == int.Parse(gameType);
                    break;

                case "A":
                    if (entryNumber.Contains(":"))
                    {
                        var  entryNums = entryNumber.Split(':');

                        status = Util.ValidateLotteryNumber(entryNums[0]) && Util.ValidateLotteryNumber(entryNums[1]);
                    }
                    else
                        status = false;
                    break;

                case "P2":
                case "P3":
                    status = Util.ValidateLotteryNumber(entryNumber);
                    break;

            }

            return status;
        }

        private bool IsAuthorizedVendor(string vendorId, string terminalId)
        {
            // TODO: confirm vendor exist and assigned this terminal
            return true;
        }

        private void LogServiceInfo(string service, string message)
        {
            //_logger.Info(string.Format("{0} - {1}", service, message));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionNumber"></param>
        /// <param name="entry"></param>
        private void SubmitEntry(string transactionNumber, EntryModelX entry)
        {
            //var _entry =  Mapping.GetDomainEntry(entry);

            //_entry.Draw = _repository.GetTodayDraw(entry.DrawId);
            //_entry.Vendor = _repository.GetVendor(entry.OperatorId);

            //_entry.TransactionNumber = transactionNumber;

            //_repository.SubmitEntry(_entry);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transactionNumber"></param>
        /// <param name="purchase"></param>
        /// <returns>return null when operator not found</returns>
        private decimal? SubmitRefill(string transactionNumber, RefillModel purchase)
        {
            //var _purchase = Mapping.GetDomainTransaction(purchase);

            //if (_repository.GetVendor(purchase.OperatorId) != null)
            //{
            //    _purchase.TransactionNumber = transactionNumber;

            //    // apply discount
            //    var config = _repository.GetConfiguration();
            //    float discount = config == null ? 0f : config.VendorDiscount / 100f;
            //    _purchase.Amount *= (decimal)(1 + discount);

            //    return _repository.RefillAccount(purchase.OperatorId, _purchase);
            //}
            //else
                return null;
        }

        private bool ValidateEntry(EntryModelX entry)
        {
            return IsValidLuckyNumber(entry.PlayNumber, entry.GameType) && IsAuthorizedVendor(entry.OperatorId, entry.TerminalId);
        }

        private bool ValidateRefill(RefillModel refill)
        {
            return !string.IsNullOrEmpty(refill.AuthCode) && !string.IsNullOrEmpty(refill.MaskedPAN) &&
                !string.IsNullOrEmpty(refill.TransactionRef);
        }

        #endregion

    }

}


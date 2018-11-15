using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using ArtifexCreditCardLibrary;
using ArtifexCreditCardLibrary.CreditCardHandler;

namespace App.Model
{    

    public class PaymentManager
    {

        public PaymentManager()
        { 
            
        }

        private ICreditCard CreateCreditCardInstance(string cardno, CreditCardType CreditCardType)
        {
            ICreditCard oCreditCard = default(ICreditCard);

            switch (CreditCardType)
            {
                case CreditCardType.adAmericanExpress:
                    oCreditCard = new AmericanExpress();
                    break;
                case CreditCardType.adDiscoverCard:
                    oCreditCard = new DiscoverCard();
                    break;
                case CreditCardType.adMasterCard:
                    oCreditCard = new MasterCard();
                    break;
                case CreditCardType.adVisa:
                    oCreditCard = new Visa();
                    break;
                default:
                    break;
            }
            

            oCreditCard.CardNumber = cardno;
            oCreditCard.CardHolderFirstName = "first name";
            oCreditCard.CardHolderLastName = "last name";
            oCreditCard.CardCode = "323";
            oCreditCard.ExpMo = DateTime.Now.AddYears(3).ToString();
            oCreditCard.ExpYr = DateTime.Now.AddYears(1).ToString();
            oCreditCard.Address = "Karachi";
            oCreditCard.City = "Washington";
            oCreditCard.State = "Washington DC";
            oCreditCard.ZipCode = "23233";
            oCreditCard.Country = "USA";
            oCreditCard.CompanyName = "USA";
            oCreditCard.Email = "arsalanata.chess@gmail.com";
            oCreditCard.Phone = "23423423";
            oCreditCard.Amount = 230;

            return oCreditCard;

        }


        public bool Pay(string creditCardNo, CreditCardType CreditCardType)
        {
            //Uri uri = new Uri("www.infichess.com", "www.infichess.com", false);

            
            ICreditCard ic = CreateCreditCardInstance(creditCardNo, CreditCardType);
            //AuthorizeNetProcessService AuthorizeNetProcessService = new AuthorizeNetProcessService(ic, "arsalanata.chess@gmail.com", "arsalanata.chess@gmail.com", "", true);
            //PayPalProcessService PayPalProcessService = new PayPalProcessService(sBusinessEmail, sItemName, 20, 0, uri.r, Uri.UriSchemeHttp, ic.isValidCardNumber);
            //string byNow = PayPalProcessService.GetBuyNowButtonHtml();

            
            
            //ArtifexCreditCardLibrary.ACHDirect acc = new ArtifexCreditCardLibrary.ACHDirect();
            //acc.AccountHolderFirstName = "";
            //acc.AccountNumber = "37828224631000533";
            //acc.AccountType = "American Express";
            //acc.Amount = 20;
            //acc.BankName = "American Express";
            //acc.LoginName = "arsalan";
            //acc.Password = "arsalan";
            //acc.State = "Washington";
            //acc.RoutingNumber = "323";
            //acc.City = "wasihington dc";
            //acc.Country = "USA";

            //ArtifexCreditCardLibrary.ACHDirect acc = new ArtifexCreditCardLibrary.ACHDirect();
            //ArtifexCreditCardLibrary.CreditCardHandler.CreditCard acc = new ArtifexCreditCardLibrary.CreditCardHandler.CreditCard();






            //base.CardHolderFirstName = "test";
            //this.CardHolderFirstName = "test";
            //this.CardHolderName = "test";

            ////acc.CardType = CreditCardType.adAmericanExpress;
            //this.CardNumber = "37828224631000533";
            //this.Amount = 20;
            //this.State = "Washington";
            //this.City = "wasihington dc";
            //this.Country = "USA";
            //this.Email = "arsalanata.chess@gmail.com";
            //this.ExpMo = "09";
            //this.ExpYr = "2000";
            ////this.ProcessYourPay(true);
            ////ArtifexCreditCardLibrary.ACHDirect acc = new ArtifexCreditCardLibrary.ACHDirect();
            //base.doMod10();
            


            //string result = base.ProcessYourPay(true);





            #region Commented code
            /*
             * 
             * Public Class PaymentMethodCreditCard
    Inherits PaymentMethodTypeBase

#Region " Constructor "

    Public Sub New(Optional ByVal bLoadFromDatabase As Boolean = True)

        If Not bLoadFromDatabase Then
            Exit Sub
        End If

        Dim dt As DataTable = data.Store.PaymentMethodType.GetByID(utilities.PaymentMethodType.CreditCard)
        If dt.Rows.Count < 1 Then
            Exit Sub
        End If

        Initialize(dt.Rows(0))

    End Sub

#End Region

#Region " Properties "

    '************************************************************************
    'Properties:    IsProcessOnline
    'Description:   If the site is configured to process credit cards online
    'Created By:    MM
    'Created On:    1/25/2005
    '************************************************************************
    Public ReadOnly Property IsProcessOnline() As Boolean
        Get
            Return BusinessRuleConfig.Instance.AreCreditCardsProcessedOnLine
        End Get
    End Property

    '************************************************************************
    'Property:      IsSecurityCodeRequired
    'Description:   If security code is required.
    '               Set in management console
    'Created By:    MM
    'Created On:    1/31/2005
    '************************************************************************
    Public ReadOnly Property IsSecurityCodeRequired() As Boolean
        Get
            Return BusinessRuleConfig.Instance.IsSecurityCodeRequired
        End Get
    End Property

    '************************************************************************
    'Property:      OrderMotionPaymentMethodType
    'Description:   Enum value
    'Created By:    MM
    'Created On:    6/30/2006
    '************************************************************************
    Public Overrides ReadOnly Property OrderMotionPaymentType() As utilities.OrderMotionPaymentType
        Get
            Return utilities.OrderMotionPaymentType.CreditCard
        End Get
    End Property

#End Region

#Region " Methods "

    '************************************************************************
    'Method:        Initialize
    'Description:   Initialize an instance from the database
    'Created By:    MM
    'Created On:    1/22/2005
    '************************************************************************
    Private Overloads Sub Initialize(ByVal oRow As DataRow)

        m_nPaymentMethodTypeID = utilities.Constants.VbInt(oRow("PaymentMethodTypeID"))
        m_sDescription = utilities.Constants.VbStr(oRow("Description"))
        m_bIsActive = utilities.Constants.VbBool(oRow("IsActive"))
        Me.m_ePaymentMethodType = utilities.PaymentMethodType.CreditCard

    End Sub

#End Region

End Class
             * */
            
            #endregion
            return ic.isValidCardNumber;
        }

        public bool Pay(string payPayInfo, int productNo)
        {
            return true;
            /*
             * Public Class PaymentMethodPayPal
    Inherits PaymentMethodTypeBase

#Region " Constructor "

    Public Sub New(Optional ByVal bLoadFromDatabase As Boolean = True)

        If Not bLoadFromDatabase Then
            Exit Sub
        End If

        Dim dt As DataTable = data.Store.PaymentMethodType.GetByID(utilities.PaymentMethodType.PayPal)
        If dt.Rows.Count < 1 Then
            Exit Sub
        End If

        Initialize(dt.Rows(0))

    End Sub

#End Region

#Region " Properties "

    Public ReadOnly Property Exists(ByVal sPayPalTransactionID As String) As Boolean
        Get
            If sPayPalTransactionID = Nothing Then
                Return False
            End If

            Return data.Store.PaymentMethodType.CheckNumberExists(Me.PaymentMethodTypeID, sPayPalTransactionID)
        End Get
    End Property

    '************************************************************************
    'Property:      OrderMotionPaymentMethodType
    'Description:   Enum value
    'Created By:    MM
    'Created On:    6/30/2006
    '************************************************************************
    Public Overrides ReadOnly Property OrderMotionPaymentType() As utilities.OrderMotionPaymentType
        Get
            Return utilities.OrderMotionPaymentType.Other
        End Get
    End Property

#End Region

#Region " Methods "

    '************************************************************************
    'Method:        Initialize
    'Description:   Initialize an instance from the database
    'Created By:    MM
    'Created On:    6/21/2005
    '************************************************************************
    Private Overloads Sub Initialize(ByVal oRow As DataRow)

        m_nPaymentMethodTypeID = utilities.Constants.VbInt(oRow("PaymentMethodTypeID"))
        m_sDescription = utilities.Constants.VbStr(oRow("Description"))
        m_bIsActive = utilities.Constants.VbBool(oRow("IsActive"))
        Me.m_ePaymentMethodType = utilities.PaymentMethodType.PayPal

    End Sub

    '************************************************************************
    'Method:        GetBuyNowButtonHtml
    'Description:   Returns html to integrate the Buy Now button into a site.
    '               Html form code is hidden on the page and a javascript method
    '               is provided to submit the request to paypal.
    '               The string returned by this method should be placed
    '               on an aspx page above the <form runat="server"> tag
    '               to avoid having nested html forms on the page.
    '               A customized button can then be placed anywhere in the page layout
    '               which calls the javascript submitPayPalForm() method.
    'Created By:    MM
    'Created On:    7/7/2005
    '************************************************************************
    Public Function GetBuyNowButtonHtml(ByVal dAmount As Decimal, ByVal dShippingCharge As Decimal) As String

        Dim oSiteConfig As SiteConfig = SiteConfig.Instance
        Dim oPayPal As New PaymentProcessor(utilities.PaymentProcessorType.PayPal)
        Dim sBusinessEmail As String = _Global.Decrypt(oPayPal.MerchantID)
        Dim sItemName As String = oSiteConfig.StoreName
        Dim oReturnUri As New Uri(oSiteConfig.SSLPath & "Checkout_Payment.aspx?CheckoutState=4")
        Dim oCancelUri As New Uri(oSiteConfig.SSLPath & "Checkout_ShipSummary.aspx?CheckoutState=3")
        Dim bIsTestMode As Boolean = oPayPal.IsTestMode

        Dim oService As New ArtifexCreditCardLibrary.CreditCardHandler.PayPalProcessService(sBusinessEmail, sItemName, dAmount, dShippingCharge, oReturnUri, oCancelUri, bIsTestMode)
        Return oService.GetBuyNowButtonHtml()

    End Function

#End Region

End Class

             * */
        }

        
    }


    //public class PaymentMethodCreditCard : PaymentMethodTypeBase
    //{

    //    #region " Constructor "


    //    public PaymentMethodCreditCard([System.Runtime.InteropServices.OptionalAttribute,
    //        System.Runtime.InteropServices.DefaultParameterValueAttribute(true)]  // ERROR: Optional parameters aren't supported in C#

    //bool bLoadFromDatabase)
    //    {
    //        if (!bLoadFromDatabase)
    //        {
    //            return;
    //        }

    //        DataTable dt = data.Store.PaymentMethodType.GetByID(utilities.PaymentMethodType.CreditCard);
    //        if (dt.Rows.Count < 1)
    //        {
    //            return;
    //        }

    //        Initialize(dt.Rows(0));

    //    }

    //    #endregion

    //    #region " Properties "

    //    //************************************************************************
    //    //Properties:    IsProcessOnline
    //    //Description:   If the site is configured to process credit cards online
    //    //Created By:    MM
    //    //Created On:    1/25/2005
    //    //************************************************************************
    //    public bool IsProcessOnline
    //    {
    //        get { return BusinessRuleConfig.Instance.AreCreditCardsProcessedOnLine; }
    //    }

    //    //************************************************************************
    //    //Property:      IsSecurityCodeRequired
    //    //Description:   If security code is required.
    //    //               Set in management console
    //    //Created By:    MM
    //    //Created On:    1/31/2005
    //    //************************************************************************
    //    public bool IsSecurityCodeRequired
    //    {
    //        get { return BusinessRuleConfig.Instance.IsSecurityCodeRequired; }
    //    }

    //    //************************************************************************
    //    //Property:      OrderMotionPaymentMethodType
    //    //Description:   Enum value
    //    //Created By:    MM
    //    //Created On:    6/30/2006
    //    //************************************************************************
    //    public override utilities.OrderMotionPaymentType OrderMotionPaymentType
    //    {
    //        get { return utilities.OrderMotionPaymentType.CreditCard; }
    //    }

    //    #endregion

    //    #region " Methods "

    //    //************************************************************************
    //    //Method:        Initialize
    //    //Description:   Initialize an instance from the database
    //    //Created By:    MM
    //    //Created On:    1/22/2005
    //    //************************************************************************

    //    private void Initialize(DataRow oRow)
    //    {
    //        m_nPaymentMethodTypeID = utilities.Constants.VbInt(oRow["PaymentMethodTypeID"]);
    //        m_sDescription = utilities.Constants.VbStr(oRow["Description"]);
    //        m_bIsActive = utilities.Constants.VbBool(oRow["IsActive"]);
    //        this.m_ePaymentMethodType = utilities.PaymentMethodType.CreditCard;

    //    }

    //    #endregion

    //}

}

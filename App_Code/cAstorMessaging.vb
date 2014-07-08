﻿Imports Microsoft.VisualBasic

Public Class cAstorMessaging
    Shared msg As String

    Public Shared Function getMsg_FreeShippingInNY() As String

        msg = "We offer free ground shipping on orders over $99 (pre-tax) in Manhattan and Brooklyn, and orders over $150 (pre-tax) elsewhere in New York State."

        Return msg
    End Function

    Public Shared Function getMsg_ThirdPartyShippingAgreement() As String

        msg = "<p>As your agent, we will assist in selecting a common carrier for the shipment of products that you have purchased and own. The majority of states maintain laws and regulations that control or restrict the importation of alcohol. In all cases, the purchaser is responsible for complying with the laws and regulations, including in particular those relating to the import of alcohol, in effect in the state to which the purchaser is shipping alcohol.</p>"

        Return msg
    End Function

    Public Shared Function getMsg_ShippingInsurance() As String
        msg = "TK"
        Return msg
    End Function

    Public Shared Function getMsg_FirstOrderFreeShipping() As String
        msg = "<p>Free shipping offer applies to first-time web orders exceeding $99 pre-tax. This offer is for free ground shipping by common carrier (FedEx or UPS). We are prohibited from shipping wine and spirits to certain states (<a href=""/m.aspx?p=free-shipping-first-order"">view a list of such states here</a>). Free shipping offer does not apply to Wine Club purchases. You must be at least 21 years of age to purchase and receive wine and spirits. All deliveries require an adult signature. In order to apply this discount, you must create an account and sign in. <a href=""/DeliveryInformation.aspx"">To create an account, click here.</a></p>"
        Return msg
    End Function


End Class

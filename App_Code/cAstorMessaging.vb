Imports Microsoft.VisualBasic

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
        msg = "<p>For 1% of your order value, you will be covered for loss or breakage. If your bottle arrives broken, or never arrives at all, let us know and we will make arrangements to replace it, free of charge.</p>" & _
        "<p>By refusing insurance, you relieve Astor Wines & Spirits of any and all responsibility for breakage or loss that may occur to your order.</p>"
        Return msg
    End Function

    Public Shared Function getMsg_FirstOrderFreeShipping() As String
        msg = "<p>Free shipping offer applies to first-time web orders exceeding $99 pre-tax. This offer is for free ground shipping by common carrier (FedEx or UPS). We are prohibited from shipping wine and spirits to certain states (<a href=""/m.aspx?p=free-shipping-first-order"">view a list of such states here</a>). Free shipping offer does not apply to Wine Club purchases. You must be at least 21 years of age to purchase and receive wine and spirits. All deliveries require an adult signature. In order to apply this discount, you must create an account and sign in. <a href=""/DeliveryInformation.aspx"">To create an account, click here.</a></p>"
        Return msg
    End Function

    Public Shared Function getMsg_ThirdPartyShipping() As String
        msg = "<p>" & _
        "Once you complete your purchase, the items you own will be transferred to a third party shipping company that works with UPS. UPS will contact you within two business days from the day your order is shipped with your tracking number, shipping date, and anticipated delivery date. Because of this transfer, delivery may take approximately 2-8 business days. There is an optional 1% charge for insurance against breakage and loss, which you can decline at checkout." & _
        "</p>"
        Return msg
    End Function

End Class

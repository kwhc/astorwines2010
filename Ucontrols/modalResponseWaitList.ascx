<%@ Control Language="VB" AutoEventWireup="false" CodeFile="modalResponseWaitList.ascx.vb" Inherits="Ucontrols_modalResponseWaitList" %>
 <asp:Panel runat="server" ID="pnlWaitListSuccess" Visible="false">
    <div id="waitListSuccess" style="display: none;">
        <p style="text-align:center;">We'll keep in touch!</p>
    </div>

     <script type="text/javascript">
         $(document).ready(function() {
             $('#waitListSuccess').modal({
                 opacity: 0
             });
         });
     </script>
 </asp:Panel>

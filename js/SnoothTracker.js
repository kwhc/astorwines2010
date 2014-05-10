// JScript File
<script type="text/javascript">
var snooth_merchant_id = 30;
var snooth_order_id = 0;
// must be formatted as a price with no dollar sign 
var snooth_order_amount = 0.0; 
// format order data as a string:
// 'sku1:price1:qty1;sku2:price2:qty2;'
var snooth_order_data = '';
var snoothtrack = new Image();
snoothtrack.src='http://www.snooth.com/track/' + snooth_merchant_id + '/' + snooth_order_id + '/' 
        + snooth_order_amount + '/' + snooth_order_data; 
</script>



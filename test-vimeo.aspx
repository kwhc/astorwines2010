<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test-vimeo.aspx.vb" Inherits="vimeoTest" MasterPageFile="~/as_master_1.master" %>

<asp:Content ContentPlaceHolderID="HeadSupplement" runat="server">

	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js"></script>

	
	<script type="text/javascript"> 
    
	    var video_id = '<%= videoID %>' ;
	    var url = 'http://vimeo.com/api/v2/video/' + video_id +'.json?callback=getTitle';

        
	    //Get Video Name
	    function init() {
	        var js = document.createElement('script');
	        js.setAttribute('type', 'text/javascript');
	        js.setAttribute('src', url);
	        document.getElementsByTagName('head').item(0).appendChild(js);
	    }
	    
	    
	    function getTitle(video) {    
	        var vidName = video[0].title;
	    }

	    window.onload = init;
	    
	    //Initiate JS Listeners

	    var moogaloop = false;

	    function vimeo_player_loaded(swf_id) {
	        moogaloop = document.getElementById(swf_id);

	        moogaloop.api_addEventListener('onFinish', 'vimeo_on_finish');
	        moogaloop.api_addEventListener('onPlay', 'vimeo_on_play');
	    }

	    function vimeo_on_play(swf_id) {
	        document.getElementById('state').innerHTML = 'Playing';
	        videoTracker._trackEvent('Play', vidName, 1);
	    }

	    function vimeo_on_finish(swf_id) {
	        document.getElementById('state').innerHTML = 'Finished';
	        videoTracker._trackEvent('Complete', vidName, 1);
	    }

	    // Run the javascript when the page is ready
	    var swf_id = 'moogaloop';

	    var flashvars = {
	        clip_id: video_id,
	        show_portrait: 1,
	        show_byline: 1,
	        show_title: 1,
	        js_api: 1, // required in order to use the Javascript API
	        js_onLoad: 'vimeo_player_loaded', // moogaloop will call this JS function when it's done loading (optional)
	        js_swf_id: 'moogaloop' // this will be passed into all event methods so you can keep track of multiple moogaloops (optional)
	    };
	    var params = {
	        allowscriptaccess: 'always',
	        allowfullscreen: 'true'
	    };
	    var attributes = {};

	    // For more SWFObject documentation visit: http://code.google.com/p/swfobject/wiki/documentation
	    swfobject.embedSWF("http://vimeo.com/moogaloop.swf", swf_id, "504", "340", "9.0.0", "expressInstall.swf", flashvars, params, attributes);
	    
	</script>



</asp:Content>


<asp:Content ContentPlaceHolderID="middleContent" runat="server">
<div class="customPage">

		<p id="name"></p>

	<h1>Vimeo Moogaloop API Example using SWFObject</h1>

	<div id="moogaloop" style="width: 504px; height: 340px;"></div>

		<p id="nameContainer">
			State: <span id="state"></span><br />
		</p>    
		
</div>

</asp:Content>
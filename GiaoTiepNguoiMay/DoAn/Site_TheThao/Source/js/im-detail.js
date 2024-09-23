$(function(){
	$(".menu-im-detail-item1").click(function(){
		$(".content-tab2,.content-tab3,.content-tab4").css("display","none");
		$(".content-tab1").css("display","block");
		$(this).css("border-bottom","5px solid #F96");
		$(".menu-im-detail-item2,.menu-im-detail-item3,.menu-im-detail-item4").css("border-bottom","0px solid #F96");
	});
	$(".menu-im-detail-item2").click(function(){
		$(".content-tab1,.content-tab3,.content-tab4").css("display","none");
		$(".content-tab2").css("display","block");
		$(this).css("border-bottom","5px solid #F96");
		$(".menu-im-detail-item1,.menu-im-detail-item3,.menu-im-detail-item4").css("border-bottom","0px solid #F96");
	});
	$(".menu-im-detail-item3").click(function(){
		$(".content-tab1,.content-tab2,content-tab4").css("display","none");
		$(".content-tab3").css("display","block");
		$(this).css("border-bottom","5px solid #F96");
		$(".menu-im-detail-item1,.menu-im-detail-item2,.menu-im-detail-item4").css("border-bottom","0px solid #F96");
	});
	$(".menu-im-detail-item4").click(function(){
		$(".content-tab1,.content-tab2,.content-tab3").css("display","none");
		$(".content-tab4").css("display","block");
		$(this).css("border-bottom","5px solid #F96");
		$(".menu-im-detail-item1,.menu-im-detail-item2,.menu-im-detail-item3").css("border-bottom","0px solid #F96");
	});
});
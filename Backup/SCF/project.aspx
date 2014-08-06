<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="project.aspx.cs" Inherits="Coop.ProjectPage" %>
<!-- #include file="includes/htmlOpen.html" -->
<div class="wrapper">
<!-- #include file="includes/header.html" -->


    <!--=== Content Part ===-->
    <div class="container content"> 	
    	<div class="row portfolio-item margin-bottom-50"> 
            <!-- Carousel -->
            <div class="col-md-7">
                <div class="carousel slide carousel-v1" id="myCarousel">
                    <div class="carousel-inner">
                        <div class="item active">
                            <img alt="" src="assets/img/main/11.jpg">
                            <div class="carousel-caption">
                                <p>Facilisis odio, dapibus ac justo acilisis gestinas.</p>
                            </div>
                        </div>
                        <div class="item">
                            <img alt="" src="assets/img/main/12.jpg">
                            <div class="carousel-caption">
                                <p>Cras justo odio, dapibus ac facilisis into egestas.</p>
                            </div>
                            </div>
                        <div class="item">
                            <img alt="" src="assets/img/main/13.jpg">
                            <div class="carousel-caption">
                                <p>Justo cras odio apibus ac afilisis lingestas de.</p>
                            </div>
                        </div>
                    </div>
                    
                    <div class="carousel-arrow">
                        <a data-slide="prev" href="#myCarousel" class="left carousel-control">
                            <i class="fa fa-angle-left"></i>
                        </a>
                        <a data-slide="next" href="#myCarousel" class="right carousel-control">
                            <i class="fa fa-angle-right"></i>
                        </a>
                    </div>
                </div>
            </div>
            <!-- End Carousel -->

            <!-- Content Info -->        
            <div class="col-md-5">
            	<h2><%=projectTitle%></h2>
                <%=projectText%>
                <ul class="list-unstyled">
                	<li><i class="fa fa-user color-green"></i> Jack Baur</li>
                	<li><i class="fa fa-calendar color-green"></i> 14,2003 February</li>
                	<li><i class="fa fa-tags color-green"></i> Websites, Google, HTML5/CSS3</li>
                </ul>
                <buton type="button" class="btn-u btn-u-large">VISIT THE PROJECT</button>
            </div>
            <!-- End Content Info -->        
        </div><!--/row-->

     

        <div class="margin-bottom-20 clearfix"></div>    

            
    </div><!--/container-->	 	
    <!--=== End Content Part ===-->
</div><!--/End Wrapepr-->

 <!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->
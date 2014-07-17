<%@ Page Language="C#" %>
<!-- #include file="includes/htmlOpen.html" -->
<div class="wrapper">
<!-- #include file="includes/header.html" -->


    <!--=== Content Part ===-->
    <div class="container content">
        <!-- About Sldier -->
        <div class="shadow-wrapper margin-bottom-50">
            <div class="carousel slide carousel-v1 box-shadow shadow-effect-2" id="myCarousel">
                <ol class="carousel-indicators">
                    <li class="rounded-x active" data-target="#myCarousel" data-slide-to="0" class="active"></li>
                    <li class="rounded-x" data-target="#myCarousel" data-slide-to="1"></li>
                    <li class="rounded-x" data-target="#myCarousel" data-slide-to="2"></li>
                </ol>

                <div class="carousel-inner">
                    <div class="item active">
                        <img class="img-responsive" src="assets/img/scf/ValleyFirst-logo.png" alt="">
                    </div>
                     <div class="item">
                        <img class="img-responsive" src="assets/img/scf/AirAcademyLogo.png" alt="">
                    </div>
                    <div class="item">
                        <img class="img-responsive" src="assets/img/scf/EnderbyLogo.jpg" alt="">
                    </div>
                    <div class="item">
                        <img class="img-responsive" src="assets/img/scf/Envision-logo.png" alt="">
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
        <!-- End About Sldier -->


    </div>    
    <!--=== End Content Part ===-->

    <!--=== Parallax About Block ===-->
    <div class="parallax-bg">            
        <div class="container content parallax-about">
            <div class="title-box-v2">
                <h2>About our company</h2>
                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <div class="banner-info light margin-bottom-10">
                        <i class="rounded-x icon-bell"></i>
                        <div class="overflow-h">
                            <h3>Our mission</h3>
                            <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tincidunt sit amet dui auctor pellentesque. Nulla ut posuere purus.</p>
                        </div>
                    </div>
                    <div class="banner-info light margin-bottom-10">
                        <i class="rounded-x fa fa-magic"></i>
                        <div class="overflow-h">
                            <h3>Our vision</h3>
                            <p>Phasellus vitae rhoncus ipsum. Aliquam ultricies, velit sit amet scelerisque tincidunt, dolor neque consequat est, a dictum felis metus eget nulla.</p>
                        </div>
                    </div>
                    <div class="banner-info light margin-bottom-10">
                        <i class="rounded-x fa fa-thumbs-o-up"></i>
                        <div class="overflow-h">
                            <h3>We are good at ...</h3>
                            <p>Nunc ac ligula ut diam rutrum porttitor. Integer et neque at lacus placerat pretium eu ac dui. Class aptent taciti sociosqu ad litora torquent per conubia nostra.</p>
                        </div>
                    </div>
                    <div class="margin-bottom-20"></div>
                </div>
                <div class="col-md-6">
                    <img class="img-responsive" src="assets/img/mockup/1.png" alt="">
                </div>
            </div>    
        </div><!--/container--> 
    </div>      
    <!--=== End Parallax About Block ===-->
</div><!--/End Wrapepr-->
   



<!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->
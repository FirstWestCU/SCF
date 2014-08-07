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
                            <img alt="" src="assets/img/scf/<%=project.ID%>/image.jpg">
                            <!--div class="carousel-caption">
                                <p>Facilisis odio, dapibus ac justo acilisis gestinas.</p>
                            </div-->
                        </div>
                     
                    </div>
                    
       
                </div>
            </div>
            <!-- End Carousel -->

            <!-- Content Info -->        
            <div class="col-md-5">
            	<h2><%=project.Name%></h2>
                <%=project.Description%>
                <ul class="list-unstyled">
                	<li><i class="fa fa-user color-green"></i> <%=project.ProposedBy.Name%></li>
                	<li><i class="fa fa-bookmark color-green"></i> <%=project.Website %></li>
                	<li><i class="fa fa-check color-green"></i> <%=projectVoteCount%></li>
                </ul>
                
                <!--Vote form-->
                <button class="btn-u" data-toggle="modal" data-target="#responsive">Vote for this Co-op</button>
                 <div class="modal fade" id="responsive" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title" id="myModalLabel">Voting Ballot </h4>
                                    </div>
                                    <div class="modal-body">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <p>
                                                    <label> First Name</label>
                                                    <input class="form-control" type="text" />
                                                </p>
                                                <p>
                                                    <label> Last Name</label>
                                                    <input class="form-control" type="text" />
                                                </p>
                                                <p>
                                                    <label>Credit Union</label>
                                                    <input class="form-control" type="text" />
                                                 </p>
                                                <p>
                                                    <label>Account Number</label>
                                                    <input class="form-control" type="text" />
                                                </p>
                                              
                                            </div>
                                       
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn-u btn-u-default" data-dismiss="modal">Close</button>
                                        <button id="voteCast_<%=project.ID%>" type="button" class="voteCast btn-u btn-u-primary">Cast Your Vote!</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



            </div>
            <!-- End Content Info -->        
        </div><!--/row-->

     

        <div class="margin-bottom-20 clearfix"></div>    

            
    </div><!--/container-->	 	
    <!--=== End Content Part ===-->
</div><!--/End Wrapepr-->

 <!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->

<script type="text/javascript">
    $(document).ready(function () {
        $(".voteCast").click(function () {
            projectId = $(this).attr("id").split('_')[1];
            url = "project.aspx/setVote";
            $.ajax({
                type: "POST",
                url: url,
                data: "{\"projectIdString\":\""+projectId +"\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    // alert(escapeHtml(msg.d));
                    // Do something interesting here.
                    // $("#content").html("<samp>" + escapeHtml(msg.d) + "</samp>");
                    alert('back');
                }
            });
        });
    });
</script>
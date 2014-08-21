﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contributions.aspx.cs" Inherits="Coop.ContributionsPage" %>

<!-- #include file="includes/htmlOpen.html" -->
<div class="wrapper">
<!-- #include file="includes/header.html" -->

       <!--=== Content Part ===-->
    <div class="container content">
        <div class="row">
            <div class="col-md-12">


                <div class="servive-block servive-block-default">
                              <h1>Contributions</h1>
              <p>
                  Credit Unions do an outstanding job telling stories about their individual community involvement.  Share below the contributions done by your credit union!.

              </p>
                <p>

                    By entering contributions, you are showing the involvment your staff had within the community, and where your dollars go.
                    After entering the information, the Sustainable Coop Fund will be able to mark it on th heat map to show a representation of your Credit Union's commmunity involvment.
                    Let us help you share and spread the word of the great work you are doing within your community.<br /><br />
                </p>
                     <p>
                    <button class="btn btn-u-lg btn-u rounded" id="enterContributions">Enter Contribution</button>
                   </p>
                                         
                </div>

             
            </div><!--cols-->
        </div><!--row-->

  


         <div class="row">
             <div class="col-md-12">
           <%
           foreach  (Coop.DonationService.Donation donation in donationList)  {
            %>
         
             <div class="col-md-6">

                 <div class="funny-boxes funny-boxes-top-sea">
                    <div class="row">
                        <div class="col-md-6 funny-boxes-img">
<%
//temp code for image placement
               int theID = donation.ID;
               int imageId = theID % 2;
               
//Get category
               Coop.CategoryService.CategoryService categoryService = new Coop.CategoryService.CategoryService();
%>


                            <img class="img-responsive" src="assets/img/scf/contrImages/<%=imageId%>.png" alt="">
                        </div>
                        <div class="col-md-6">
                           
                                <label><%=donation.DonatingCreditUnion.Name%></label>
                          
                              <p>
                                 <label><%=categoryService.GetDonationCategoryDescription(donation.Category)%></label>
                            </p>
                              <p>
                               <label>  <%=donation.Title%></label>
                                  <address style="text-align:right">
                                <%=donation.Address1%><br />
<%
               if (!String.IsNullOrEmpty(donation.Address2)) { 
%>
                                <%=donation.Address2%><br />
<% 
}
%>
                                <%=donation.City%>,   <%=donation.State%> <%=donation.ZIP%><br />
                                <%=donation.Country%>
                                      </address>
                            </p>
                              <p>
                                 <label>Contributed Dollar Value</label> <%=donation.Dollars%>
                            </p>
                              <p>
                                  <label>Other Contributions(non-monetary)</label><%=donation.OtherContributionsValue %>
                            </p>
                       
                       </div>
                    </div>  
                     <div class="row">
                          <div class="col-md-12">
                            <label>Description</label> <%=donation.AdditionalInfo%>
                            </div>
                     </div>                          
                </div>



            </div>
            <%
            }
             %>


            </div><!--cols-->
        </div><!--row-->
    </div><!--/container-->		
    <!--=== End Content Part ===-->
</div><!--/End Wrapepr-->
 <!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->

<script type="text/javascript">
    $(document).ready(function () {


        $("#enterContributions").click(function () {
            location.href = "contribution.aspx";
        });
      

    });
</script>
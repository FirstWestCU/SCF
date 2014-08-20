<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contribution.aspx.cs" Inherits="Coop.ContributionPage" %>
<!-- #include file="includes/htmlOpen.html" -->
<div class="wrapper">
<!-- #include file="includes/header.html" -->

       <!--=== Content Part ===-->
    <div class="container content">
        <div class="row">
            <div class="col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">

                <form id="contributionForm" method="post" action="contribution.aspx/addContribution">
                    <label>Credit Union Name</label>
                         <select name="creditUnionId" class="form-control margin-bottom-20">
                                    <%foreach (Coop.CreditUnionService.CreditUnion creditUnion in creditUnionList){ %>
                                        <option value="<%=creditUnion.ID %>"><%=creditUnion.Name %></option>
                                    <%
                                    }
                                    %>
                                    </select>
                   <label>Contribution Category</label>
                         <select name="categoryId" class="form-control margin-bottom-20">
                                    <%foreach (Coop.CategoryService.Category category in categoryList){ %>
                                        <option value="<%=category.ID %>"><%=category.Description %></option>
                                    <%
                                    }
                                    %>
                                    </select>
                    <div>
                        <label>Charity Address 1</label>
                        <input type ="text" id="address1" name="address1" class="form-control margin-bottom-20">
                    </div>
                    <div>
                        <label>Charity Address 2</label>
                        <input type ="text" id="address2"  name="address2" class="form-control margin-bottom-20">
                    </div>                
                     <div>
                        <label>City</label>
                        <input type ="text" id="city" name="city" class="form-control margin-bottom-20">
                    </div>
                     <div>
                        <label>State/Province</label>
                        <input type ="text" id="provState" name="provState" class="form-control margin-bottom-20">
                    </div>
                    <div>
                        <label>ZIP/Postal Code</label>
                        <input type ="text" id="postalZip" name="postalZip" class="form-control margin-bottom-20">
                    </div> 
                     <div>
                        <label>Country</label>
                        <input type ="text" id="country" name="country" class="form-control margin-bottom-20">
                    </div> 
                       <div>
                        <label>Charity or Organization Name</label>
                        <input type ="text" name="charityName" class="form-control margin-bottom-20">
                    </div>
                    <div>
                     
                        <p><button id="contributionFormButton" type="submit" class="btn-u">Submit</button></p>
                    </div>

                </form>

            </div>
        </div>
    </div><!--/container-->		
    <!--=== End Content Part ===-->
</div><!--/End Wrapepr-->
 <!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->

<script type="text/javascript">
    $(document).ready(function () {


        //Does not need to be document on
        $(document).on('submit', '#contributionForm', function () {
      

            var url = $(this).attr('action');
            var type = $(this).attr('method');
            var data = $(this).serializeObject();

            //First look up Lat and Long based on address   
            var geoLocaterAddress = $("#address1").val() + ", " + $("#address2").val() + ", " + $("#city").val() + ", " + $("#provState").val() + ", " + $("#postalZip").val() + ", " + $("#country").val();
      
           GMaps.geocode({
                address: geoLocaterAddress,
                callback: function (results, status) {
                    if (status == 'OK') {
                        var latlng = results[0].geometry.location;
                        var lat = latlng.lat();
                        var long = latlng.lng();
                        data["lat"]=lat;
                        data["lng"]=long;

                       // alert(data);

                        data = JSON.stringify(data),

                        //Now submit to server (via ajax)
                          $.ajax({
                              type: type,
                              url: url,
                              data: data,
                              contentType: "application/json; charset=utf-8",
                              dataType: "json",
                              success: function (msg) {
                                  // alert(escapeHtml(msg.d));
                                  // Do something interesting here.
                                  // $("#content").html("<samp>" + escapeHtml(msg.d) + "</samp>");
                                  location.href = "contributions.aspx";
                              }
                          });


                    } else {

                        alert(status);
                    }
                }
            });//end geocode
     
            return false;
        });

      
      
        //TODO - move to script utilities
        $.fn.serializeObject = function () {
            var o = {};
            var a = this.serializeArray();
            $.each(a, function () {
                if (o[this.name]) {
                    if (!o[this.name].push) {
                        o[this.name] = [o[this.name]];
                    }
                    o[this.name].push(this.value || '');
                } else {
                    o[this.name] = this.value || '';
                }
            });
            return o;
        };


    });
</script>
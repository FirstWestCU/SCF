<%@ Page Language="C#" %>
<!-- #include file="includes/htmlOpen.html" -->
<div class="wrapper">
<!-- #include file="includes/header.html" -->

    <!--=== Content Part ===-->
    <div class="container content">
        <div class="row">

            <!-- Begin Content -->
            <div class="col-md-12">
                <div class="heading heading-v1 margin-bottom-40">
                    <h2>Heat Map</h2>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p>
                </div>

                <!-- Basic Map -->
                <div class="headline"><h3>Basic Map</h3></div>
                <div id="map" class="map margin-bottom-50"></div>
                <!-- End Basic Map -->

            </div>
            <!-- End Content -->
        </div>          
    </div><!--/container-->     
    <!--=== End Content Part ===-->




</div><!--/End Wrapepr-->
<!-- #include file="includes/footer.html" -->
<!-- #include file="includes/htmlClose.html" -->
<script type="text/javascript">
    $(document).ready(function () {

        var map;

        var mapOptions = {
            zoom: 7,
            center: new google.maps.LatLng(50.000, -124.000),
            mapTypeId: google.maps.MapTypeId.SATELLITE
        };

        map = new google.maps.Map(document.getElementById('map'),
      mapOptions);






        var addresses = [
    "2387, Ware St, Abbotsford, BC,V2S3C6, Canada",
    "2420, Montrose Avenue, Abbotsford BC, V2S3S9, Canada",
    "33914 Essendene Ave. Abbotsford BC Canada V2S2H8",
    "2838 Justice Way Abbotsford BC Canada V2T3P5",
    "20550 Fraser Hwy LangleyBC Canada V3A4G2",
    "938 West 28th Avenue Vancouver BC Canada V5Z4H4",
    "463-4800 Kingsway Burnaby BC Canada V5H4J2",
    "5946 12th Avenue Tsawwassen BC Canada V4L1C7",
    "4631 Clarence Taylor Crescent	Delta BC, V4K 4L8, Canada",
    "5800, Mountain View Blvd, Delta, BC, V4K3V6, Canada",
    "9097, 120 Street, Delta, BC, V4C6R7, Canada",
    "P.O Box 2503, New Westminister, BC, V3L5B2, Canada",
    "5034, Emmerson Road, Abbotsford, BC, V3G3C1, Canada",
    "13595, King George Blvd, Surrey, BC, V3T2V1, Canada",
    "85, Winson Road, Abbotsford, BC, V2S8E8, Canada",
    "45600, Menholm Road, Chilliwak, BC, V2P1P7, Canada",
    "P.O. Box 998, 895 Third Avenue, Hope, BC, V0X1L0, Canada",
    "#8-22726, Dewdney Trunk Road, Maple Ridge, BC,	V2X3K2, Canada",
    "Hope Brigade Days,	Box 1702, Hope, BC, V0X1L0, Canada",
    "Hope Community Services Society, Box 74-434 Wallace Street, Hope, BC, V0X 1L0, Canada",
    "Kitimat Concert Series, P.O Box 99, Kitimat, BC, V8C 2G6, Canada",
    "Kitimat Food Bank,	14 Morgan St, Kitimat, BC, V8C 1J3, Canada",
    "Kiwanis Fraser Valley Music Festival, 32305 Badger Ave, Mission, BC, V2V 5H8, Canada",
    "Kwantlen Polytechnic University, 12666, 72nd Ave, Surrey, BC, V3W 2M8, Canada",
    "Ladner Village Quilt Walk & Classic Car Show (Ladner Business Association), PO Box 15, STN MAIN, Delta, BC, V4K 3N5, Canada",
    "Langley Christmas Bureau, 20560 Fraser Highway, Langley, BC, V3A 4G2, Canada",
    "Langley Environmental Partners Society, 201, 4839 221 Street, Langley, BC,	V3A 2P1, Canada",
    "Langley Food Bank,	5768 203 St., Langley, BC, V3A1W3",
    "Langley Montessori School,	21488, Old Yale Road, Langley, BC, V3A4M8, Canada",
    "Langley RCMP, 22180 - 48A Avenue, Langley, BC,	V3A8B7, Canada",
    "Langley School District Foundation, 4875, 222nd Street, Langley, BC,V3A3Z7, Canada",
    "Langley Senior Resources Society, 20605, 51B Avenue, Langley, BC, V3A9H1, Canada",
    "Maples Discovery Gardens Co-op, 7743 200th St, Langley, BC, V2Y1S3, Canada",
    "Mission Community Services Society/Christmas Bureau, 32646 Logan Ave, Mission, BC, V2V6C7, Canada", 
    "Mission Heritage Association, PO Box 3341, Mission, BC, V2V 4J5, Canada",
    "Peninsula Community Foundation, 250-2411 160th st, Surrey, BC,	V3S0C8, Canada", 
    "PowerPlay Strategies, PO Box 45034, Ocean Park RPO, Surrey, BC, V4A9L1, Canada",
    "Progressive Intercultural Community Services, #205 12725 80th Avenue, Surrey, BC, V3W3A6, Canada", 	 	 
    "Ridge Meadows Hospital Foundation, 11666 Laity Street, Box 5000, Maple Ridge, BC, V2X7G5, Canada",
    "Run for Water Society, 204-2190 west railway st, Abbotsford, BC, V2S2E2, Canada",
    "SAINTS Rescue, 33860 Dlugosh Avenue, Mission, BC, V2V6B2, Canada",
    "Salvation Army Care and Share Centre, 45746 Yale Rd, Chilliwack, BC, V2P2N5, Canada",
    "Salvation Army, Caring Place, 22188 Lougheed Hwy, Maple Ridge, BC, V2X2S8, Canada",
    "Salvation Army, Gateway of Hope, 5787 Langley Bypass, Langley, BC,	V3A0A9, Canada",
    "Salvation Army, White Rock	15417 Roper Ave, White Rock, BC, V4B2G4, Canada",
    "Seniors Come Share Society, 15008 26th Avenue, Surrey, BC, V4P3H5, Canada",
    "Share Family & Community Services Society	Top of Form
2615 Clarke Street
Bottom of Form	Port Moody	Top of Form
V3H 1Z4 
Bottom of Form
Sikh Academy	12895 85th Ave	Surrey	V3W-0K8
SOS Children’s Village	102-5830 176A Street	Surrey	V3S 4H5 	 	 
Sources Food Bank	2343 – 156 St.,  	South Surrey	V4A 4V5
Sources Rent Bank	#102-13771 72A Ave	Surrey	V3W 9C6
South Delta Food Bank	5545 Ladner trunk road	Delta	V4K 1X1
St. Joseph’s Food Bank	32550 7th ave	Mission	V2V 2B9
Success By 6	4543 Canada Way	Burnaby	V5G 4T4 
Sunshine Valley Ratepayer’s Association	P.O Box 2104	Hope	V0X 1L0
Surrey Board of Trade	14439-104 ave, #101	Surrey	V3R 1M1
Surrey Food Bank	10732 City Parkway	Surrey	V3T 4C7
Surrey International Children’s Festival (Surrey Arts Centre- Bear Creek Park)	13750 - 88 Avenue	Surrey	V3W 3L1
Surrey School District, Envision Financial Jazz Festival	14033 92nd ave	Surrey	V3V 0B7
Tillicum Adult Learning Centre	1166 7th Ave	Hope	V0X 1L4
True North Fraser Bluegrass Society	23994 119B ave 	Maple Ridge	V4R 1W4
United Way of the Fraser Valley	P208 33355 Bevan Ave.	Abbotsford 	V2S 0E7
University of the Fraser Valley	33844 King Road 	Abbotsford 	V2S 7M8
Vantage Point	1183 Melville Street	Vancouver	V6E 2X5
Yarrow Volunteer Society	4670 Community St	Chilliwack 	V2R 5E1
YWCA Metro Vancouver	4 – 535 Hornby Street	Vancouver 	V6C 2E8



];


        var longLatData = [];

        var callbackcount = 0;
        //Loop through addresses
        for (var i = 0; i < addresses.length; i++) {
            taddress = addresses[i];
            // alert(taddress);
            GMaps.geocode({
                address: taddress,
                callback: function (results, status) {

                    callbackcount++;

                    if (status == 'OK') {
                        var latlng = results[0].geometry.location;
                        // alert(latlng.lat());
                        /*map.addMarker({
                        lat: latlng.lat(),
                        lng: latlng.lng()
                        });*/
                        //alert(latlng.lat());
                        longLatData.push(new google.maps.LatLng(latlng.lat(), latlng.lng()));

                    } else {
                        //   alert(taddress);
                    }

                    if (callbackcount == addresses.length) {
                        // alert(longLatData.length);
                        var pointArray = new google.maps.MVCArray(longLatData);
                        //  alert(pointArray.length);
                        heatmap = new google.maps.visualization.HeatmapLayer({
                            data: pointArray
                        });

                        heatmap.setMap(map);
                    }

                }
            });
        } //end for

       

    });
</script>
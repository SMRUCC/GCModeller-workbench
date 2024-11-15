<!doctype html>
<html lang="en">

<?vb $title = "Motif Viewer" ?>
<?vb $app = "motif_viewer" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>

        <script type="plain/text" id="pwm">
    letter-probability matrix: alength= 4 w= 20 nsites= 264 E= 8.0e-104 
    0.007576 0.424242 0.515152 0.05303
    0.219697 0.465909 0.314394 0
    0.325758 0.128788 0.011364 0.534091
    0 0.147727 0.825758 0.026515
    0.219697 0.375 0.32197 0.083333
    0.276515 0.189394 0.132576 0.401515
    0.022727 0.280303 0.560606 0.136364
    0.079545 0.234848 0.670455 0.015152
    0.340909 0.526515 0 0.132576
    0.155303 0.25 0.515152 0.079545
    0.143939 0.405303 0.295455 0.155303
    0.215909 0.162879 0 0.621212
    0 0.17803 0.82197 0
    0.113636 0.386364 0.420455 0.079545
    0.212121 0.30303 0.159091 0.325758
    0 0.549242 0.390152 0.060606
    0.272727 0.204545 0.522727 0
    0.409091 0.344697 0.064394 0.181818
    0.128788 0.443182 0.348485 0.079545
    0.181818 0.231061 0.477273 0.109848
</script>
</head>

<body>

    <div class="container-fluid container">

        <h1>View Motif Logo</h1>

        <div class="row">
            <div class="col-auto">

                <div id="preview_1">

                </div>

            </div>
        </div>


        <%= ../../assets/includes/webapp.vbhtml %>

            <script src="/javascript/viewer.min.js" type="text/javascript"></script>

    </div>

</body>

</html>
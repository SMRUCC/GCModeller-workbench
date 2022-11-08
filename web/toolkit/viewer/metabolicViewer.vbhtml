<!doctype html>
<html lang="en">

<?vb $title = "Metabolic Model Viewer" ?>
<?vb $app = "metabolic_viewer" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>
</head>

<body>

    <div class="container-fluid container">

        <h1>View Metabolic Network Model</h1>

        <div class="row">
            <div class="col-auto">

                <ul id="compartment-list"></ul>

                <div id="preview_1">

                </div>

            </div>
        </div>


        <%= ../../assets/includes/webapp.vbhtml %>

            <script src="/javascript/viewer.min.js" type="text/javascript"></script>

    </div>

</body>

</html>
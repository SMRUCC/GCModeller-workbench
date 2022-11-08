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
            <div class="col-3">

                <select id="compartment_list" class="form-control select-input placeholder-active active">

                </select>

            </div>

            <div class="col-auto">
                <div class="row">
                    <div id="enzyme-class" class="col-auto" style="width: 450px;height:400px;">

                    </div>
                </div>
                <div class="row">
                    <div class="col-auto">
                        <ul id="reaction-graph-data">

                        </ul>
                    </div>
                </div>

            </div>
        </div>


        <%= ../../assets/includes/webapp.vbhtml %>

            <script src="/javascript/viewer.min.js" type="text/javascript"></script>
            <script src="/javascript/echarts-5.4.0/echarts.min.js" type="text/javascript"></script>
    </div>

</body>

</html>
<!doctype html>
<html lang="en">

<?vb $title = "Localblast Viewer" ?>
<?vb $app = "blastp_viewer" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>
</head>

<body>

    <div class="container-fluid container">

        <h1>View Localblast result</h1>

        <div class="row">
            <div class="col-auto">
                <div class="alert alert-success" role="alert" data-mdb-color="success">
                    <i class="fas fa-check-circle me-3"></i>
                    get <span id="number_proteins"></span> Proteins
                </div>

            </div>
        </div>

        <div class="row">
            <div class="col-auto">

                <div id="preview_1" style="width: 450px;height:400px;">

                </div>

            </div>
        </div>

        <div class="row">
            <div class="col-1">
                <button id="previous" type="button" class="btn btn-primary mb-3">Previous</button>
            </div>
            <div class="col-10" style="text-align: center;">
                <span id="protein_id"></span>
            </div>
            <div class="col-1">
                <button id="next" type="button" class="btn btn-primary mb-3">Next</button>
            </div>
        </div>

        <div class="row">
            <div class="col-auto" id="blast_output">
            </div>
        </div>

        <%= ../../assets/includes/webapp.vbhtml %>

            <script src="/javascript/viewer.min.js" type="text/javascript"></script>
            <script src="/javascript/echarts-5.4.0/echarts.min.js" type="text/javascript"></script>
    </div>

</body>

</html>
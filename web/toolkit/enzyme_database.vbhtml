<!DOCTYPE html>
<html lang="en">

<?vb $title = "Enzyme Database Repository" ?>
<?vb $app = "enzyme_database" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/database/ec_numbers?rweb_background=true">
        <link rel="stylesheet" href="/javascript/vakata-jstree-7a03954/themes/default/style.min.css" />
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <h1>Enzyme Database</h1>

        <div class="row">
            <div class="col-2">
                <div id="enzyme-tree">

                </div>
            </div>
            <div class="col-10" id="protein-panel">

            </div>
        </div>

        <div class="row">
            <div class="col">

                <h2>Install Rhea Reactions</h2>

                <label for="rhea-file" class="form-label">Select UniProt Assembly:</label>
                <div class="input-group mb-3">
                    <button class="btn btn-primary" type="button" id="button_open_rhea" data-mdb-ripple-color="dark">
                        <i class="far fa-folder-open"></i> Open UniProt
                    </button>
                    <input type="text" class="form-control" placeholder="" id="rhea-file"
                        aria-label="Example text with button addon" aria-describedby="button-addon1" />
                </div>

                <button class="btn btn-primary" type="button" id="run_rhea" data-mdb-ripple-color="dark">
                    <i class="far fa-folder-open"></i> Build Database
                </button>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <h2>Create Enzyme Annotation Blast Database</h2>

                <label for="matrix-file" class="form-label">Select UniProt Assembly:</label>
                <div class="input-group mb-3">
                    <button class="btn btn-primary" type="button" id="button_open_uniprot" data-mdb-ripple-color="dark">
                        <i class="far fa-folder-open"></i> Open UniProt
                    </button>
                    <input type="text" class="form-control" placeholder="" id="uniprot-file"
                        aria-label="Example text with button addon" aria-describedby="button-addon1" />
                </div>

                <button class="btn btn-primary" type="button" id="run" data-mdb-ripple-color="dark">
                    <i class="far fa-folder-open"></i> Build Database
                </button>
            </div>
        </div>

        <%= ../assets/includes/webapp.vbhtml %>

            <script type="text/javascript" src="/javascript/jquery-3.6.1.min.js"></script>
            <script type="text/javascript" src="/javascript/vakata-jstree-7a03954/jstree.min.js"></script>

    </div>
    <!-- End your project here-->
</body>

</html>
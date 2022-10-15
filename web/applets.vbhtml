<!DOCTYPE html>
<html lang="en">

<?vb $title = "Applications" ?>
<?vb $app = "applets" ?>

<head>
    <%= ./assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/database/imports_uniprot">
        <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_database">

        <style type="text/css">
            .card-body {
                padding: 0.25rem;
                padding-left: 0.75rem;
            }

            .icon-image {
                width: 64px;
                height: 64px;
            }

            .background {
                position: relative;
                background-image: url("/assets/images/dna-image.jpg");
                background-position: center;
                background-repeat: no-repeat;
                background-size: cover;
                /* height: 100%;
                filter: blur(8px);
                 */
            }
        </style>
</head>

<body class="background">
    <!-- Start your project here-->
    <div class="container" style="background: rgba(0, 0, 0, 0.3); padding: 30px 30px 30px 30px;">

        <h1 style="color: white;">GCModeller Analysis Applications</h1>
<br />
        <div class="row">
            <div class="col-xl-4 col-lg-6 mb-4">
                <a href="#" onclick="apps.gcmodeller.openZscore();" class="card ripple bg-image hover-zoom">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <img src="/assets/images/background.jpg" alt="" class="img-fluid rounded icon-image" />
                            <div class="ms-3">
                                <p class="fw-bold mb-1">Z-score analysis</p>
                                <p class="text-muted mb-0">Z-score analysis</p>
                            </div>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-xl-4 col-lg-6 mb-4">
                <a href="#" onclick="apps.gcmodeller.openDataEmbedding();" class="card ripple bg-image hover-zoom">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <img src="/assets/images/background.jpg" alt="" class="img-fluid rounded icon-image" />
                            <div class="ms-3">
                                <p class="fw-bold mb-1">Data Embedding</p>
                                <p class="text-muted mb-0">PCA/UMAP/t-SNE data embedding</p>
                            </div>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-xl-4 col-lg-6 mb-4">
                <a href="#" onclick="apps.gcmodeller.openCMeans();" class="card ripple bg-image hover-zoom">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <img src="/assets/images/background.jpg" alt="" class="img-fluid rounded icon-image" />
                            <div class="ms-3">
                                <p class="fw-bold mb-1">Fuzzy CMeans</p>
                                <p class="text-muted mb-0">Fuzzy cmeans clustering</p>
                            </div>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-xl-4 col-lg-6 mb-4">
                <a href="#" onclick="" class="card ripple bg-image hover-zoom">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <img src="/assets/images/background.jpg" alt="" class="img-fluid rounded icon-image" />
                            <div class="ms-3">
                                <p class="fw-bold mb-1">Fuzzy CMeans</p>
                                <p class="text-muted mb-0">Fuzzy cmeans clustering</p>
                            </div>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-xl-4 col-lg-6 mb-4">
                <a href="#" onclick="" class="card ripple bg-image hover-zoom">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <img src="/assets/images/background.jpg" alt="" class="img-fluid rounded icon-image" />
                            <div class="ms-3">
                                <p class="fw-bold mb-1">Fuzzy CMeans</p>
                                <p class="text-muted mb-0">Fuzzy cmeans clustering</p>
                            </div>
                        </div>
                    </div>
                </a>
            </div>
            <div class="col-xl-4 col-lg-6 mb-4">
                <a href="#" onclick="apps.gcmodeller.openPLAS();" class="card ripple bg-image hover-zoom">
                    <div class="card-body">
                        <div class="d-flex align-items-center">
                            <img src="/assets/images/background.jpg" alt="" class="img-fluid rounded icon-image" />
                            <div class="ms-3">
                                <p class="fw-bold mb-1">PLAS</p>
                                <p class="text-muted mb-0">bio-chemical system simulator</p>
                            </div>
                        </div>
                    </div>
                </a>
            </div>
        </div>

        <%= ./assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>
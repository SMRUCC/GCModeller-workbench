<!DOCTYPE html>
<html lang="en">

<?vb $title = "Welcome To the GCModeller Workbench" ?>
<?vb $app = "main_page" ?>

<head>
    <%= ./assets/includes/head.vbhtml %>

        <meta name="web_invoke_imports" content="http://localhost:7452/database/imports_uniprot">
        <meta name="web_invoke_inspector" content="http://localhost:7452/database/inspect_database">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">
        <div class="row">
            <div class="col-8">
                <br />

                <h1>GCModeller <img src="/assets/images/zenodo.159947.svg"></h1>
                <hr />
                <h5>
                    GCModeller: genomics CAD(Computer Assistant Design) Modeller System
                </h5>
                <div class="row">
                    <div class="col-auto">
                        <p>
                            <strong>Get Start</strong>
                        </p>

                        <ul>
                            <li><a>Create New Analysis Project</a></li>
                            <li><a>New Virtual Cell Modelling Project</a></li>
                            <li><a>Open Project</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-4" style="text-align: left;">
                <img src="/logo.png" style="max-height: 250px;">
            </div>
        </div>

        <div class="row">
            <br />
            <br />
        </div>

        <div class="row">
            <div class="row">
                <div class="col-6">
                    <div class="row">
                        <div class="col-4 hover-zoom">
                            <a href="#" class="card h-100" onclick="apps.gcmodeller.openApplets();">
                                <img src="/assets/icons/applications.png" class="card-img-top"
                                    alt="Palm Springs Road" />
                                <div class="card-body">
                                    <h5 class="card-title">Apps</h5>
                                    <p class="card-text">
                                        <!-- Run data analysis apps from gcmodeller workbench -->
                                    </p>
                                </div>
                            </a>
                        </div>
                        <div class="col-4 hover-zoom">
                            <a href="#" class="card h-100" onclick="apps.gcmodeller.openDatabaseRepository();">
                                <img src="/assets/icons/drive-multidisk.png" class="card-img-top"
                                    alt="Los Angeles Skyscrapers" />
                                <div class="card-body">
                                    <h5 class="card-title">Repository</h5>
                                    <p class="card-text">
                                        <!-- Database file managements -->
                                    </p>
                                </div>
                            </a>
                        </div>
                        <div class="col-4 hover-zoom">
                            <a href="#" class="card h-100" onclick="apps.gcmodeller.openTaskManager();">
                                <img src="/assets/icons/task-manager.png" class="card-img-top" alt="Skyscrapers" />
                                <div class="card-body">
                                    <h5 class="card-title">Task Manager</h5>
                                    <p class="card-text">
                                        <!-- View the local data analysis task list. -->
                                    </p>
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="col-6" style="font-size: 0.85em;">
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-8">
                            <h5>Your Favourites</h5>

                            <ul id="pin-list" style="list-style: none; text-indent: 0%;">
                                <li><i class="fas fa-thumbtack"></i> &nbsp; <a href="#"
                                        onclick="apps.gcmodeller.openDataEmbedding();">Data Embedding Analysis</a></li>
                                <li><i class="fas fa-thumbtack"></i> &nbsp;
                                    <a href="#" onclick="apps.gcmodeller.openDataEmbedding();">Enrichment Analysis</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

        </div>


        <!-- Footer -->
        <footer class="text-center text-lg-start text-muted" style="font-size: 0.8em;">
            <!-- Section: Social media -->
            <section class="d-flex justify-content-center justify-content-lg-between p-4 border-bottom">
                <!-- Left -->
                <div class="me-5 d-none d-lg-block">

                </div>
                <!-- Left -->

                <!-- Right -->
                <div>
                    <a href="https://github.com/SMRUCC/GCModeller-workbench" class="me-4 text-reset">
                        <i class="fab fa-github"></i>
                    </a>
                </div>
                <!-- Right -->
            </section>
            <!-- Section: Social media -->

            <!-- Section: Links  -->
            <section class="">
                <div class="container text-center text-md-start mt-5">
                    <!-- Grid row -->
                    <div class="row mt-3">
                        <!-- Grid column -->
                        <div class="col-md-3 col-lg-4 col-xl-3 mx-auto mb-4">
                            <!-- Content -->
                            <h6 class="text-uppercase fw-bold mb-4">
                                <i class="fas fa-gem me-3"></i>SMRUCC genomics
                            </h6>
                            <p>
                                Here you can use rows and columns to organize your footer content. Lorem ipsum
                                dolor sit amet, consectetur adipisicing elit.
                            </p>
                        </div>
                        <!-- Grid column -->

                        <!-- Grid column -->
                        <div class="col-md-2 col-lg-2 col-xl-2 mx-auto mb-4">
                            <!-- Links -->
                            <h6 class="text-uppercase fw-bold mb-4">
                                Products
                            </h6>
                            <p>
                                <a href="https://github.com/rsharp-lang" class="text-reset">R# Language</a>
                            </p>
                        </div>
                        <!-- Grid column -->

                        <!-- Grid column -->
                        <div class="col-md-3 col-lg-2 col-xl-2 mx-auto mb-4">
                            <!-- Links -->
                            <h6 class="text-uppercase fw-bold mb-4">
                                Useful links
                            </h6>
                            <p>
                                <a href="https://github.com/SMRUCC/GCModeller" class="text-reset">Open Source</a>
                            </p>
                            <p>
                                <a href="#!" class="text-reset">Help</a>
                            </p>
                        </div>
                        <!-- Grid column -->

                        <!-- Grid column -->
                        <div class="col-md-4 col-lg-3 col-xl-3 mx-auto mb-md-0 mb-4">
                            <!-- Links -->
                            <h6 class="text-uppercase fw-bold mb-4">Contact</h6>
                            <p><i class="fas fa-home me-3"></i> GuiLin, China</p>
                            <p>
                                <i class="fas fa-envelope me-3"></i>
                                <a href="mailto://genomics@gcmodeller.org">genomics@gcmodeller.org</a>
                            </p>
                            <!--<p><i class="fas fa-phone me-3"></i> + 01 234 567 88</p>
                            <p><i class="fas fa-print me-3"></i> + 01 234 567 89</p>-->
                        </div>
                        <!-- Grid column -->
                    </div>
                    <!-- Grid row -->
                </div>
            </section>
            <!-- Section: Links  -->

            <!-- Copyright -->
            <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.05);">
                © 2022 Copyright:
                <a class="text-reset fw-bold" href="https://gcmodeller.org/">GCModeller.org</a> | 中國 · 桂林
            </div>
            <!-- Copyright -->
        </footer>
        <!-- Footer -->


        <%= ./assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>
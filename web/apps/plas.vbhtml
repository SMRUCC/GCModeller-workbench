<!DOCTYPE html>
<html lang="en">

<?vb $title = "Computational Analysis Of Biochemical Systems" ?>
<?vb $app = "plas" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

        <meta name="web_invoke_run_plas" content="http://localhost:7452/analysis_apps/plas">
        <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/Rplots/line2d">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <div class="row">
            <div class="col-md-8">
                <!-- Spied element -->
                <div data-mdb-spy="scroll" data-mdb-target="#scrollspy1" data-mdb-offset="0" class="scrollspy-example">
                    <section id="example-1">
                        <h3>Introduction</h3>
                        <p>
                            A true understanding of genetic and metabolic function and design is facilitated by
                            mathematical and computational methods for analyzing biochemical systems. This hands-on
                            reference teaches biochemists and molecular biologists the use of modern computational
                            methods for the analysis of complex biomedical systems requiring a modest mathematical
                            background.
                        </p>
                    </section>
                    <section id="example-2">
                        <h3>Set Parameters</h3>
                        ...
                    </section>
                    <section id="example-3">
                        <h3>Analysis Result</h3>
                        ...
                        <section id="example-sub-A">
                            <h3>Rplot</h3>
                            ...
                        </section>
                        <section id="example-sub-B">
                            <h3>Data Table</h3>
                            ...
                        </section>
                    </section>
                    <section id="example-4">
                        <h3>Reference</h3>
                        ...
                    </section>
                    <section id="example-5">
                        <h3>Download</h3>
                        ...
                    </section>
                </div>
                <!-- Spied element -->
            </div>

            <div class="col-md-4">
                <!-- Scrollspy -->
                <div id="scrollspy1" class="sticky-top">
                    <ul class="nav flex-column nav-pills menu-sidebar">
                        <li class="nav-item">
                            <a class="nav-link" href="#example-1">Introduction</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-2">Set Parameters</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-3">Analysis Result</a>
                            <ul class="nav flex-column ps-3">
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-A">Rplot</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" href="#example-sub-B">Data Table</a>
                                </li>
                            </ul>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-4">Reference</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#example-5">Download</a>
                        </li>
                    </ul>
                </div>
                <!-- Scrollspy -->
            </div>
        </div>

        <%= ../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>
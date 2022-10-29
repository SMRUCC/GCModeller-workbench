<!DOCTYPE html>
<html lang="en">

<?vb $title = "NCBI localblast+" ?>
<?vb $app = "localblast" ?>

<head>
    <%= ../../assets/includes/head.vbhtml %>

        <meta name="web_invoke_localblast" content="http://localhost:7452/modeller/localblast?rweb_background=true">
</head>

<body>
    <!-- Start your project here-->
    <div class="container">

        <h1>NCBI localblast+</h1>

        <div class="row">
            <div class="col-md-8">
                <!-- Spied element -->
                <div data-mdb-spy="scroll" data-mdb-target="#scrollspy1" data-mdb-offset="0" class="scrollspy-example">
                    <section id="example-1">
                        <h3>Introduction</h3>

                        <div class="clearfix">
                            <img class="col-md-6 float-md-end mb-3 ms-md-3 hover-shadow hover-zoom"
                                src="/assets/images/localblast.jpg" style="width: 300px;">

                            <p>
                                The Basic Local Alignment Search Tool (BLAST) finds regions of local similarity between
                                sequences. The program compares nucleotide or protein sequences to sequence databases
                                and calculates the statistical significance of matches. BLAST can be used to infer
                                functional and evolutionary relationships between sequences as well as help identify
                                members of gene families.
                            </p>
                        </div>

                    </section>
                    <section id="example-2">
                        <h3>Set Parameters</h3>

                        <div class="row">
                            <div class="col">
                                <label for="protocols">Protocols:</label>
                                <select id="protocols" class="form-select">
                                    <option selected value="sbh">Single BestHit</option>
                                    <option value="ontology_annotation">Ontology Annotation</option>
                                </select>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">

                                <label for="query-file" class="form-label">Select Query:</label>
                                <div class="input-group mb-3">
                                    <button class="btn btn-primary" type="button" id="button_open_query"
                                        data-mdb-ripple-color="dark">
                                        <i class="far fa-folder-open"></i> Select File
                                    </button>
                                    <input type="text" class="form-control" placeholder="" id="query-file"
                                        aria-label="Example text with button addon" aria-describedby="button-addon1" />
                                </div>

                            </div>
                        </div>

                        <div class="row">
                            <div class="col">

                                <label for="reference-file" class="form-label">Select Reference:</label>
                                <div class="input-group mb-3">
                                    <button class="btn btn-primary" type="button" id="button_open_reference"
                                        data-mdb-ripple-color="dark">
                                        <i class="far fa-folder-open"></i> Select File
                                    </button>
                                    <input type="text" class="form-control" placeholder="" id="reference-file"
                                        aria-label="Example text with button addon" aria-describedby="button-addon1" />
                                </div>

                            </div>
                        </div>

                        <br />
                        <div class="row">
                            <div class="col-auto">
                                <button id="run" type="submit" class="btn btn-primary mb-3">Run</button>
                            </div>
                        </div>
                    </section>
                    <section id="example-3">
                        <h3>Analysis Result</h3>


                        <section id="example-sub-A">
                            <h3>Rplot</h3>

                            <section class="pb-4">
                                <div class="bg-white border rounded-5">

                                    <section class="p-4 d-flex justify-content-center text-center w-100">
                                        <div class="lightbox" data-id="lightbox-bm48lj2vb" id="lightbox">
                                            <div class="row">
                                                <div class="col-auto">
                                                    <a href="/assets/images/empty.jpg" data-toggle="lightbox"
                                                        data-caption="2d/3d scatter plot" id="Rplot-box">
                                                        <img src="/assets/images/empty.jpg" alt="2d/3d scatter plot"
                                                            class="img-fluid w-100 my-lightbox-toggle"
                                                            style="max-width: 400px;" id="Rplot_js">
                                                    </a>
                                                </div>

                                            </div>
                                        </div>
                                    </section>

                                </div>
                            </section>

                        </section>
                        <section id="example-sub-B">
                            <h3>Data Table</h3>

                            <div class="row">
                                <div class="col-auto" id="result-table">

                                </div>
                            </div>

                        </section>
                    </section>
                    <section id="example-4">
                        <h3>Reference</h3>

                        <ol>
                            <li>Altschul, S.F., Gish, W., Miller, W., Myers, E.W. &amp; Lipman, D.J. (1990) “Basic local
                                alignment search tool.” J. Mol. Biol. 215:403-410. PubMed</li>

                            <li>Gish, W. &amp; States, D.J. (1993) “Identification of protein coding regions by database
                                similarity search.” Nature Genet. 3:266-272. PubMed</li>

                            <li>Madden, T.L., Tatusov, R.L. &amp; Zhang, J. (1996) “Applications of network BLAST
                                server”
                                Meth. Enzymol. 266:131-141. PubMed</li>

                            <li>Altschul, S.F., Madden, T.L., Sch&auml;ffer, A.A., Zhang, J., Zhang, Z., Miller, W.
                                &amp;
                                Lipman, D.J. (1997) “Gapped BLAST and PSI-BLAST: a new generation of protein database
                                search
                                programs.” Nucleic Acids Res. 25:3389-3402. PubMed</li>

                            <li>Zhang Z., Schwartz S., Wagner L., &amp; Miller W. (2000), “A greedy algorithm for
                                aligning
                                DNA sequences” J Comput Biol 2000; 7(1-2):203-14. PubMed</li>

                            <li>Zhang, J. &amp; Madden, T.L. (1997) “PowerBLAST: A new network BLAST application for
                                interactive or automated sequence analysis and annotation.” Genome Res. 7:649-656.
                                PubMed</li>

                            <li>Morgulis A., Coulouris G., Raytselis Y., Madden T.L., Agarwala R., &amp; Sch&auml;ffer
                                A.A.
                                (2008) “Database indexing for production MegaBLAST searches.” Bioinformatics
                                15:1757-1764.
                                PubMed</li>

                            <li>Camacho C., Coulouris G., Avagyan V., Ma N., Papadopoulos J., Bealer K., &amp; Madden
                                T.L.
                                (2008) “BLAST+: architecture and applications.” BMC Bioinformatics 10:421. PubMed</li>

                            <li>Boratyn GM, Sch&auml;ffer AA, Agarwala R, Altschul SF, Lipman DJ, &amp; Madden T.L.
                                (2012)
                                “Domain enhanced lookup time accelerated BLAST.” Biol Direct. 2012 Apr 17;7:12. PubMed
                            </li>

                            <li>Boratyn GM, Thierry-Mieg J, Thierry-Mieg D, Busby B, Madden T.L. (2019) “Magic-BLAST, an
                                accurate RNA-seq aligner for long and short reads.” BMC Bioinformatics. 2019 Jul
                                25;20(1):405. PubMed</li>
                        </ol>

                    </section>
                    <section id="example-5">
                        <h3>Download</h3>

                        <p>Save your analysis result files.</p>

                        <div class="btn-group" role="group" aria-label="Button group with nested dropdown">
                            <button type="button" class="btn btn-info" id="save_project">
                                Save To Project
                            </button>

                            <div class="btn-group" role="group">
                                <button id="download-group" type="button" class="btn btn-primary dropdown-toggle"
                                    data-mdb-toggle="dropdown" aria-expanded="false">
                                    Download Report
                                </button>
                                <ul class="dropdown-menu" aria-labelledby="download-group">
                                    <li><a class="dropdown-item" href="#" id="download_zip">Download Zip Archive</a>
                                    </li>
                                    <li><a class="dropdown-item" href="#">Print As PDF</a></li>
                                </ul>
                            </div>
                        </div>
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




        <%= ../../assets/includes/webapp.vbhtml %>

    </div>
    <!-- End your project here-->
</body>

</html>
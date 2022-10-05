<!DOCTYPE html>
<html lang="en">

<?vb $title = "Gene Set Enrichment Tool" ?>
<?vb $app = "enrichment_analysis" ?>

<head>
    <%= ../assets/includes/head.vbhtml %>

    <meta name="web_invoke_enrichment" content="http://localhost:7452/analysis_apps/enrichment">
    <meta name="web_invoke_Rplot" content="http://localhost:7452/analysis_apps/enrichment_plot">
</head>

<body>
  <!-- Start your project here-->
  <div class="container">

    <!-- Tabs navs -->
    <ul class="nav nav-tabs mb-3" id="ex-with-icons" role="tablist">
      <li class="nav-item" role="presentation">
        <a class="nav-link active" id="ex-with-icons-tab-1" data-mdb-toggle="tab" href="#ex-with-icons-tabs-1"
          role="tab" aria-controls="ex-with-icons-tabs-1" aria-selected="true"><i
            class="fas fa-chart-pie fa-fw me-2"></i>Run Enrichment Analysis</a>
      </li>
      <li class="nav-item" role="presentation">
        <a class="nav-link" id="ex-with-icons-tab-2" data-mdb-toggle="tab" href="#ex-with-icons-tabs-2" role="tab"
          aria-controls="ex-with-icons-tabs-2" aria-selected="false">
          <i class="fas fa-cogs fa-fw me-2"></i>
          Analysis
          Result
        </a>
      </li>
    </ul>
    <!-- Tabs navs -->

    <!-- Tabs content -->
    <div class="tab-content" id="ex-with-icons-content">
      <div class="tab-pane fade show active" id="ex-with-icons-tabs-1" role="tabpanel"
        aria-labelledby="ex-with-icons-tab-1">

        <div class="row">

          <section class="pb-4">
            <div class="bg-white rounded-5">

              <section class="w-100 p-4 pb-4 d-flex justify-content-center">
                <div style="width: 22rem;">
                  <label for="background" class="form-label">Select an enrichment background:</label>
                  <select id="background" class="select form-select" data-mdb-option-height="44">
                    <optgroup label="Annotation Ontology Information">
                      <option value="GO" data-mdb-secondary-text="Secondary text">Gene Ontology</option>
                      <option value="keyword" data-mdb-secondary-text="Secondary text">UniProt Keyword Ontology</option>
                    </optgroup>
                    <optgroup label="Protein Structures">
                      <option value="Pfam" data-mdb-secondary-text="Secondary text">Pfam</option>
                      <option value="InterPro" data-mdb-secondary-text="Secondary text">InterPro</option>
                    </optgroup>
                  </select>

                  <p id="go_note" style="display: block;">
                    The Gene Ontology (GO) is a major bioinformatics initiative to unify the representation of gene and
                    gene product attributes across all species.
                  </p>
                  <p id="uniprot_note" style="display: none;">UniProtKB (Universal Protein Knowledge Base) is a
                    collection of functional information on proteins. UniProtKB entries are tagged with keywords
                    (controlled vocabulary) that can be used to retrieve particular subsets of entries. These keyword
                    belongs to categories and have complex structure in it self.</p>
                  <p id="pfam_note" style="display: none;">
                    The general purpose of the Pfam database is to provide a complete and accurate classification of
                    protein families and domains. Originally, the rationale behind creating the database was to have
                    a semi-automated method of curating information on known protein families to improve the efficiency
                    of annotating genomes.
                  </p>
                  <p id="interpro_note" style="display: none;">
                    InterPro provides functional analysis of proteins by classifying them into families and predicting
                    domains and important sites. To classify proteins in this way, InterPro uses predictive models,
                    known as signatures, provided by several different databases (referred to as member databases) that
                    make up the InterPro consortium.
                  </p>
                </div>
              </section>
            </div>
          </section>

        </div>
        <div class="row">
          <div class="col">
            <label for="input_idlist" class="form-label">Input Gene Symbols:</label>
            <textarea class="form-control" id="input_idlist" rows="3"></textarea>
          </div>
        </div>
        <div class="row">
          <div class="col-auto">
            <button id="run" type="submit" class="btn btn-primary mb-3">Run</button>
          </div>
        </div>

      </div>
      <div class="tab-pane fade" id="ex-with-icons-tabs-2" role="tabpanel" aria-labelledby="ex-with-icons-tab-2">

        <div class="row">
          <div class="col" id="canvas">
            <h5>Enrichment Visual Plot</h5>

            <section class="pb-4">
              <div class="bg-white border rounded-5">

                <section class="p-4 d-flex justify-content-center text-center w-100">
                  <div class="lightbox" data-id="lightbox-bm48lj2vb" id="lightbox">
                    <div class="row">
                      <div class="col-lg-4">
                        <a href="/assets/images/empty.jpg" data-toggle="lightbox" data-caption="Enrichment Plot"
                          id="Rplot-box">
                          <img src="/assets/images/empty.jpg" src="/assets/images/empty.jpg" alt="Enrichment Plot"
                            class="img-fluid w-100 my-lightbox-toggle" style="width: 30%;" id="Rplot">
                        </a>
                      </div>

                    </div>
                  </div>
                </section>

              </div>
            </section>


            <div class="row">
              <div class="col-auto">
                <button id="plot" type="button" class="btn btn-primary mb-3">Plot</button>
              </div>
            </div>
          </div>
        </div>
        <hr />
        <div class="row">
          <div id="enrichment-result-table" class="col"></div>
        </div>

      </div>

    </div>
    <!-- Tabs content -->

    <%= ../assets/includes/webapp.vbhtml %>

  </div>
  <!-- End your project here-->
</body>

</html>
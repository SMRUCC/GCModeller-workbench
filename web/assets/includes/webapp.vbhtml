<div id="busy-indicator" style="
z-index:999999; 
position: absolute; 
left: -25%; 
top: 0; 
float: left; 
width: 150%;
height: 100%; 
background-color: rgba(0, 0, 0, 0.555); 
display: none;">

  <div class="d-flex justify-content-center"
    style="position: absolute; left: 50%; top: 50%; transform: translate(0, -50%); color: white;">

    <div class="spinner-border" role="status">
      <span class="visually-hidden"></span>
    </div>

    <div>
      &nbsp;&nbsp;&nbsp; Loading...
    </div>

  </div>
</div>


<div id="toast-message" class="toast-container position-fixed bottom-0 end-0 p-3" style="z-index: 11">
</div>

<!-- MDB -->
<script type="text/javascript" src="/styles/bootstrap-5.0.2-dist/js/bootstrap.bundle.min.js"></script>
<script type="text/javascript" src="/styles/bootstrap5/js/mdb.min.js"></script>
<!-- Custom scripts -->
<script src="/javascript/linq.min.js" type="text/javascript"></script>
<script src="/javascript/biocad_desktop.min.js" type="text/javascript"></script>
<script src="/javascript/bs5-lightbox.bundle.min.js" type="text/javascript"></script>
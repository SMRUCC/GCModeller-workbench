// export R# source type define for javascript/typescript language
//
// package_source=Rstudio

declare namespace Rstudio {
   module _ {
      /**
      */
      function onLoad(): object;
   }
   /**
     * @param code default value Is ``0``.
   */
   function echo_successMsg(data: any, code?: object): object;
   module fs {
      /**
      */
      function ec_numbers_fasta(): object;
      /**
      */
      function metabolic_db(): object;
      /**
      */
      function subcellular_locations_fasta(): object;
   }
   /**
     * @param z_score default value Is ``true``.
   */
   function matrixFileReader(file: any, z_score?: boolean): object;
}

// export R# package module type define for javascript/typescript language
//
//    imports "Modeller" from "GCModellerDesktop";
//
// ref=GCModeller.Modeller@GCModellerDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null

/**
*/
declare namespace Modeller {
   /**
   */
   function build_metabolic_network(proj: string, rhea: object): any;
   /**
   */
   function extract_proteinset_fasta(proj: string, save: string): any;
   /**
     * @param env default value Is ``null``.
   */
   function loadProject(assembly: any, env?: object): object;
   /**
   */
   function readProj(proj: string): any;
   /**
   */
   function save_enzyme_annotation(proj: string, anno: string): any;
   /**
   */
   function save_subcellular_location(proj: string, anno: string): any;
   /**
     * @param env default value Is ``null``.
   */
   function writeProject(proj: object, file: any, env?: object): boolean;
}

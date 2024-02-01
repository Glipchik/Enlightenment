import ModuleReview from "../models/ModuleReview/ModuleReview";
import GenericService from "./GenericService";

export default class ModuleReviewService extends GenericService<ModuleReview> {
  constructor() {
    super();
    this.url = `${process.env.REACT_APP_ENLIGHTENMENT_API}/api/module-reviews`;
  }
}

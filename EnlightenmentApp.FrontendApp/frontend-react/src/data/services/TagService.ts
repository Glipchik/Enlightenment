import Tag from "../models/Tag/Tag";
import GenericService from "./GenericService";

export default class TagService extends GenericService<Tag> {
  constructor() {
    super();
    this.url = `${process.env.REACT_APP_ENLIGHTENMENT_API}/api/tags`;
  }
}

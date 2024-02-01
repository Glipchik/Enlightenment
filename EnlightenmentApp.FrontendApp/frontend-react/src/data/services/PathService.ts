import Path from "../models/Path/Path";
import GenericService from "./GenericService";

export default class PathService extends GenericService<Path> {
  constructor() {
    super();
    this.url = `${process.env.REACT_APP_ENLIGHTENMENT_API}/api/paths`;
  }
}

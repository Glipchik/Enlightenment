import Section from "../models/Section/Section";
import GenericService from "./GenericService";

export default class SectionService extends GenericService<Section> {
  constructor() {
    super();
    this.url = `${process.env.REACT_APP_ENLIGHTENMENT_API}/api/sections`;
  }
}

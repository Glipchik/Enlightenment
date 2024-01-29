import { Module } from "../data/models/Module/Module";
import GenericService from "./GenericService";

export default class ModuleService extends GenericService<Module> {
  constructor() {
    super();
    this.url = `${process.env.REACT_APP_ENLIGHTENMENT_API}/api/modules`;
  }
}

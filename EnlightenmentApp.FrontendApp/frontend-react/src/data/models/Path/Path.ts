import Tag from "../Tag/Tag";
import Module from "../Module/Module";

export default class Path {
  id: number = 0;
  title: string = "";
  summary: string = "";
  cost: number = 0;
  tags: Tag[] = [];
  modules: Module[] = [];
}

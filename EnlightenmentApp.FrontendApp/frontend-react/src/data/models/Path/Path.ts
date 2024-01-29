import Tag from "../Tag/Tag";
import { Module } from "../Module/Module";

export default interface Path {
  id: number;
  title: string;
  summary: string;
  cost: number;
  tags: Tag[] | null;
  modules: Module[];
}

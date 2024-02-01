import axios, { AxiosError } from "axios";

export default class GenericService<T> {
  url: string = "";

  async get(): Promise<T[]> {
    const { data } = await axios
      .get<T[]>(this.url, {
        headers: {
          Accept: "application/json",
        },
      })
      .catch((err: AxiosError) => {
        console.log(err.message);
        return { data: [], ...err };
      });
    return data;
  }

  async getById(id: number): Promise<T> {
    const { data } = await axios
      .get<T>(`${this.url}/${id}`, {
        headers: {
          Accept: "application/json",
        },
      })
      .catch((err: AxiosError) => {
        console.log(err.message);
        return { data: {} as T, ...err };
      });
    return data;
  }

  async add(item: T): Promise<T> {
    const { data } = await axios
      .post<T>(`${this.url}`, item, {
        headers: {
          Accept: "application/json",
        },
      })
      .catch((err: AxiosError) => {
        console.log(err.message);
        return { data: {} as T, ...err };
      });
    return data;
  }

  async update(id: number, item: T): Promise<T> {
    const { data } = await axios
      .put<T>(`${this.url}/${id}`, item, {
        headers: {
          Accept: "application/json",
        },
      })
      .catch((err: AxiosError) => {
        console.log(err.message);
        return { data: {} as T, ...err };
      });
    return data;
  }

  async delete(id: number): Promise<T> {
    const { data } = await axios
      .delete<T>(`${this.url}/${id}`, {
        headers: {
          Accept: "application/json",
        },
      })
      .catch((err: AxiosError) => {
        console.log(err.message);
        return { data: {} as T, ...err };
      });
    return data;
  }
}

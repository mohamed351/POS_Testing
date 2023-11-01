export interface Product {
  id: number
  productName: string
  details: Detail[]
}

export interface Detail {
  id: number
  productName: string
  parentId?: number
  quantity: number
  quantityBase: number
  children:Detail[]

}



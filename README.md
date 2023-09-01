# GraphQLPlayground

Url to playground: https://localhost:7028/ui/playground

## Query:

### Get all customers:
```
{
  customers{
    id,
    firstName,
    lastName,
    orders
    {
      id,
      status
    }   
  }
}
```
![image](https://github.com/tumanina/GraphQLPlayground/assets/17797666/e8d00143-e999-4cc5-b4c6-6cd5b33ca077)

### Get customer by id
```
{
  customerById(id: "aeab639a-efd1-4bf2-81d8-0c068f7cc692"){
    id,
    firstName,
    lastName,
    orders
    {
      id,
    	status
    }   
  }
}
```
![image](https://github.com/tumanina/GraphQLPlayground/assets/17797666/f1dc053c-bc00-4c50-8e99-91221e17e2d2)
### Get all orders:
```
{
  orders{
    id,
    status,
    customer
    {
      id,
      firstName,
      lastName
    }
  }
}
```
![image](https://github.com/tumanina/GraphQLPlayground/assets/17797666/49e2fbaf-0fd9-44a2-823d-32fb58a9b2f2)

### Get order by id:
```
{
  orderById(id: "026f0bd5-dfe6-4b77-942c-9ab5aabbd4f6"){
    id,
    status,
    customer
    {
      id,
      firstName,
      lastName
    }
  }
}
```
![image](https://github.com/tumanina/GraphQLPlayground/assets/17797666/509c59b5-9e8f-4041-a4cf-0279d2bb718c)

## Mutations (Command)

### Create customer:
```
mutation
{
  createCustomer(firstName: "James", lastName:"Test", notes: "some notes")
  {
    id, 
    firstName,
    lastName,
    notes
  }
}
```
![image](https://github.com/tumanina/GraphQLPlayground/assets/17797666/c8d5bf02-5946-4ab1-8b8a-f44c70d3f284)

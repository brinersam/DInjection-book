using System.Collections.Generic;

// namespace ECom.Domain // im so lost
// {
//     public class EntryPoint
//     {
//         public EntryPoint()
//         {

//         }

//         public IEnumerable<ProductViewModel> Run()
//         {
//             var controller = new HomeController();

//             var service = new ProductService
//             (
//                 new CommerceJSONContext(null),
//                 new UserInfo(UserData.I.IsInRole(UserRole.PreferredCustomer)),
//                 discountMod: .50m
//             );

//             return controller.ViewAdapter(service.GetFeaturedProducts());
//         }
//     }
// }
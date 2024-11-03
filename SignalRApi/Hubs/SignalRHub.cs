using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;

        private readonly ITableDetailService _tableDetailService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        private readonly IMessageService _messageService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, ITableDetailService tableDetailService, IBookingService bookingService, INotificationService notificationService, IMessageService messageService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;

            _tableDetailService = tableDetailService;
            _bookingService = bookingService;
            _notificationService = notificationService;
            _messageService = messageService;
        }

        public static int clientCount { get; set; } = 0;

        public async Task SendStatistic()
        {
            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var productCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var activeCategoryCount = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", activeCategoryCount);

            var passiveCategoryCount = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", passiveCategoryCount);

            var hamburgerCount = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveHamburgerCount", hamburgerCount);

            var drinkCount = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);

            var averageCount = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveAveragePrice", averageCount);

            var productNameByMaxPrice = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", productNameByMaxPrice);

            var productNameByMinPrice = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", productNameByMinPrice);

            var averageHamburgerPrice = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", averageHamburgerPrice);

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice);

            var totalMoneyCase = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCase", totalMoneyCase);

            var todayTotalPrice = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", todayTotalPrice);

            var totalTableCount = _tableDetailService.TTableCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", totalTableCount);


        }

        public async Task SendProgress()
        {
            var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount);

            var activeOrderCount = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", activeOrderCount);

            var totalTableCount = _tableDetailService.TTableCount();
            await Clients.All.SendAsync("ReceiveTotalTableCount", totalTableCount);

            var averageProductPrice = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveAverageProductPrice", averageProductPrice);

            var averageHamburgerPrice = _productService.TProductAvgPriceByHamburger();
            await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", averageHamburgerPrice);

            var drinkCount = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveDrinkCount", drinkCount);

            var productCount = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", productCount);

            var categoryCount = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", categoryCount);

            var activeBookingCount = _bookingService.TActiveBookingCount();
            await Clients.All.SendAsync("ReceiveActiveBookingCount", activeBookingCount);
        }

        public async Task GetBookingList()
        {
            var bookingList = _bookingService.TGetListAll();
            await Clients.All.SendAsync("ReceiveBookingList", bookingList);
        }

        public async Task SendNotification()
        {
            var notificationCountStatusFalse = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountStatusFalse", notificationCountStatusFalse);

            var notificationListByFalse = _notificationService.TGetNotificationListByFalse();
            await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);

            var messageCountStatusFalse = _messageService.TMessageCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveMessageCountStatusFalse", messageCountStatusFalse);
        }

        public async Task GetTableDetailStatus()
        {
            var tableDetailList = _tableDetailService.TGetListAll();
            await Clients.All.SendAsync("ReceiveTableDetailStatus", tableDetailList);
        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}

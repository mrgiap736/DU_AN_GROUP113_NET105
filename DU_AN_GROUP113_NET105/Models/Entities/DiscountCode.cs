namespace DU_AN_GROUP113_NET105.Models.Entities
{
    public class DiscountCode
    {
        public string Id { get; set; } //Id này sẽ tự nhập và nó sẽ là code để khách nhập luôn 
        public int Value { get; set; } //Giá trị mã 
        public int Condition { get; set; } //Kiểu như tổng đơn hàng phải lớn hơn ... mới được áp dụng mã
        public int Quantity { get; set; } //Số lượng mã 
        public int Status { get; set; } //Tình trạng mã 

        //Quan hệ
        public Guid CategoryId { get; set; } 
        public DiscountCategory DiscountCategory { get; set; }
        public Cart Cart { get; set; }

    }
}

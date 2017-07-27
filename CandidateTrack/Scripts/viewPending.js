$(function () {
    $('.container').on('click', '.action', function () {
        var row = $(this);
        var id = $(row).attr('data-id');
        var action = $(row).attr('data-action');
        $.post('/home/UpdateCandidate', { Id: id, action: action }, function (result) {
            $('.view-pending').text(result.PendingCount);
            $('.view confirmed').text(result.ConfirmedCount);
            $('.view-refused').text(result.RefusedCount);
            $(row).closest('.btn-container').remove();
        });
    })
})
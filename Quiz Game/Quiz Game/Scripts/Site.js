$(document).ready(function () {
    positionMainWindow(); // position main window

    $('.div-nav').each(function () {
        $(this).click(function (e) {
            if ($(this).hasClass('active'))
                return false; // disable button if active
            window.location.href = $(this).attr('goto'); // redirect to the other page ( game / settings )
        });
    });

    $('.btn-answer').each(function () {
        var btn = $(this);
        $(this).click(function () {
            $.getJSON('/Home/CheckAnswer?',
            { quoteid: $(this).attr('qid') },
            function (data) {
                var correct = parseInt(data[0].AnswerID);
                var current = parseInt(btn.attr('aid'));
                var answer = data[0].AnswerText;

                if (btn.hasClass('btn')) {
                    if ((correct == current && btn.attr('correct') == '1') || (correct != current && btn.attr('correct') == '0'))
                        $('#modal-text').html('Correct! The right answer is: ' + answer);
                    else
                        $('#modal-text').html('Sorry, you are wrong! The right answer is: ' + answer);
                }
                else {
                    if (correct == current)
                        $('#modal-text').html('Correct! The right answer is: ' + answer);
                    else
                        $('#modal-text').html('Sorry, you are wrong! The right answer is: ' + answer);
                }
                $('#modalResult').modal();
            }
            );
        });
    });

    $('#modalResult').on('hidden.bs.modal', function () {
        window.location.reload();
    })
});
function positionMainWindow() {
    // center the main window
    $('.div-game').css('left', ($(window).width() - $('.div-game').width()) / 2).css('top', ($(window).height() - $('.div-game').height()) / 2);
}
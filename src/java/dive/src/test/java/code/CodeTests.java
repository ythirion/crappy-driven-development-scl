package code;

import lombok.val;
import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import static org.assertj.core.api.Assertions.assertThat;

class CodeTests {
    @Test
    void should_move_on_given_instructions() {
        var instructions = loadInstructions();
        var submarine = new K991_P(0, 0);

        submarine.toString(instructions);

        assertThat(calculateResult(submarine)).isEqualTo(1690020);
    }

    private int calculateResult(K991_P submarine) {
        return submarine.getB().getM() * submarine.getB().getStr();
    }

    private List<P67580_ALL> loadInstructions() {
        return Arrays.stream(FileUtils.getInputAsSeparatedLines("submarine.txt"))
                .map(P67580_ALL::rescue)
                .collect(Collectors.toUnmodifiableList());
    }
}
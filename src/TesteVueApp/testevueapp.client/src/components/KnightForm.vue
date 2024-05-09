<!-- KnightForm.vue -->
<template>
    <div style="width:200px">
        <form @submit.prevent="submitForm" class="form">
            <div class="row">
                <div class="form-group">
                    <label for="name">Nome:</label>
                    <input type="text" class="form-control" id="name" v-model="knight.name">
                </div>

                <div class="form-group">
                    <label for="nickname">Apelido:</label>
                    <input type="text" class="form-control" id="nickname" v-model="knight.nickname">
                </div>


            </div>
            <div class="row">
                <div class="form-group">
                    <label for="birthday">Data de Nascimento:</label>
                    <input type="date" class="form-control" id="birthday" v-model="knight.birthday">
                </div>
                <div class="form-group">
                    <label for="keyAttribute">Atributo Chave:</label>
                    <select class="form-control" id="keyAttribute" v-model="knight.keyAttribute">
                        <option value="Strength">Força</option>
                        <option value="dexterity">Destreza</option>
                        <option value="constitution">Constituição</option>
                        <option value="intelligence">Inteligência</option>
                        <option value="wisdom">Sabedoria</option>
                        <option value="charisma">Carisma</option>
                    </select>
                </div>
            </div>
            <div class="row">
                <div class="form-group">
                    <label for="weapon">Arma:</label>
                    <input type="text" class="form-control" id="weapon" v-model="weaponName" style="width:100px">&nbsp;
                    <label for="mod">Modificador:</label>
                    <input type="number" class="form-control" id="mod" v-model.number="weaponMod" style="width:30px">&nbsp;
                    <label for="attr">Atributo:</label>
                    <select class="form-control" id="attr" v-model="weaponAttr">
                        <option value="strength">Força</option>
                        <option value="speed">Velocidade</option>
                        <option value="precision">Precisão</option>
                        <option value="range">Alcance</option>
                        <option value="Crush">Esmagamento</option>
                    </select>&nbsp;
                    <label for="equipped">Equipada:</label>
                    <input type="checkbox" class="form-control" id="equipped" v-model="weaponEquipped">&nbsp;
                    <button type="button" @click="addWeapon">+</button>
                </div>
            </div>
            <div class="row">
                <h3>Armas Adicionadas</h3>
                <ul>
                    <li v-for="(weapon, index) in knight.weapons" :key="index">
                        <strong>Nome:</strong> {{ weapon.name }}, <strong>Modificador:</strong> {{ weapon.mod }},
                        <strong>Atributo:</strong> {{ weapon.attr }}, <strong>Equipada:</strong> {{ weapon.equipped ? 'Sim' : 'Não' }}
                        <!-- Botão para remover a arma -->
                        <button type="button" @click="removeWeapon(index)">Remover</button>
                    </li>
                </ul>
            </div>


            <button type="button" class="btn btn-primary" @click="submitForm(); ">{{ editMode ? 'Editar' : 'Cadastrar' }}</button>
        </form>
    </div>
</template>

<script>
    export default {
        props: {
            knight: {
                type: Object,
                default: () => ({ weapons: [] })
            },
            editMode: {
                type: Boolean,
                default: false
            }
        },
        data() {
            return {
                //formData: {
                //    name: '',
                //    nickname: '',
                //    birthday: '',
                //    weapons: [],
                //    keyAttribute: 'strength'
                //},
                weaponName: '',
                weaponMod: 0,
                weaponAttr: '',
                weaponEquipped: false
            };
        },
        methods: {
            addWeapon() {

                if (this.knight.weapons == undefined) this.knight.weapons = [];

                this.knight.weapons.push({
                    name: this.weaponName,
                    mod: this.weaponMod,
                    attr: this.weaponAttr,
                    equipped: this.weaponEquipped
                });

                // Limpar os campos após adicionar a arma
                this.weaponName = '';
                this.weaponMod = 0;
                this.weaponAttr = '';
                this.weaponEquipped = false;
            },

            submitForm() {
                this.$emit('submit', this.knight);
            },
            removeWeapon(index) {
                this.knight.weapons.splice(index, 1);
            },
        }
        ,
        watch: {
            // Reiniciar submitting após a emissão do evento de envio
            '$parent.knights': function () {
                this.submitting = false;
                this.$refs.formRef.reset(); // Limpar o formulário
            }
        }
    };
</script>

<style scoped>

    .row {
        display: flex;
        flex-wrap: wrap;
        width: 580px;
        border: 1px solid green;
        margin-bottom: 5px
    }

    .form-group {
        flex: auto;
        margin-right: 10px;
    }
</style>
